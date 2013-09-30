using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleInformationalApp.Startup))]
namespace SimpleInformationalApp
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
