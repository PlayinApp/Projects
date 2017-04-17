using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Webmvc.Startup))]
namespace Webmvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
