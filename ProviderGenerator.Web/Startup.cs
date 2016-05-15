using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProviderGenerator.Web.Startup))]
namespace ProviderGenerator.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
