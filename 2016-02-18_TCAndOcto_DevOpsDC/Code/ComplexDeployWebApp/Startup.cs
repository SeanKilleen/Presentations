using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ComplexDeployWebApp.Startup))]
namespace ComplexDeployWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
