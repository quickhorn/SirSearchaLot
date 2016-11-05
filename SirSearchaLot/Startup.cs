using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SirSearchaLot.Startup))]
namespace SirSearchaLot
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
