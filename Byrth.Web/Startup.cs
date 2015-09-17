using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Byrth.Web.Startup))]
namespace Byrth.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
