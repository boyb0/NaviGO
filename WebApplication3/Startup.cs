using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NaviGO.Startup))]
namespace NaviGO
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
