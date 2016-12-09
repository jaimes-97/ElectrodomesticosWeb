using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ElectrodomesticosWeb.Startup))]
namespace ElectrodomesticosWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
