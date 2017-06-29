using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppforms.Startup))]
namespace WebAppforms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
