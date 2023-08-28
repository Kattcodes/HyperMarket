using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HyperMarket.UI.Startup))]
namespace HyperMarket.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
