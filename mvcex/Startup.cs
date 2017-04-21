using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcex.Startup))]
namespace mvcex
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
