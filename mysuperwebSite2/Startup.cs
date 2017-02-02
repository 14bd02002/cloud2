using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mysuperwebSite2.Startup))]
namespace mysuperwebSite2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
