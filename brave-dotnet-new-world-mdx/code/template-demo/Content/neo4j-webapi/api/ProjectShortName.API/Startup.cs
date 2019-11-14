using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Neo4jClient;

namespace ProjectShortName.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<IGraphClient>(x =>
            {
                var host = Configuration["Neo4j:Hostname"];
                var port = Configuration["Neo4j:Port"];
                var username = Configuration["Neo4j:User"];
                var password = Configuration["Neo4j:Password"];

                Uri neo4JUri;
                GraphClient graphClient;
                try
                {
                    neo4JUri = new Uri($"http://{host}:{port}/db/data");
                    graphClient = new GraphClient(neo4JUri, username, password);
                    graphClient.Connect();
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred when trying to create the connection string with host '{host}' and port '{port}'", ex);
                }

                return graphClient;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
