using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Locations.Web.Startup))]
namespace Locations.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
