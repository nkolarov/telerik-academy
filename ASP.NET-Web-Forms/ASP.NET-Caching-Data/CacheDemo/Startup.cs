using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CacheDemo.Startup))]
namespace CacheDemo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
