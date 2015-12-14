using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcAppWithAuth.Startup))]
namespace MvcAppWithAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
