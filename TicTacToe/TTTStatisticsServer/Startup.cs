using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TTTStatisticsServer.Startup))]
namespace TTTStatisticsServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
