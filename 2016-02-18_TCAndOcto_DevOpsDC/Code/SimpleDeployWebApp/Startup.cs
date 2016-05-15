using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleDeployWebApp.Startup))]
namespace SimpleDeployWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
