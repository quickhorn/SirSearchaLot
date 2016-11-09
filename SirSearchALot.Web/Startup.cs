using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SirSearchALot.Web.Startup))]
namespace SirSearchALot.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
