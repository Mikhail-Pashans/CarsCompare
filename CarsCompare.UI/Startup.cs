using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarsCompare.UI.Startup))]
namespace CarsCompare.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}