using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using ZooApp.MvcClient.Models;

[assembly: OwinStartup(typeof(ZooApp.MvcClient.Startup))]

namespace ZooApp.MvcClient
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // context store
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
              //  Provider = new CookieAuthenticationProvider()
            });

        }
    }
}
