using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(MvcAppEmpty.Startup))]

namespace MvcAppEmpty
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888     
            GlobalFilters.Filters.Add(new AuthorizeAttribute());

            CookieAuthenticationOptions options =new CookieAuthenticationOptions();
            options.AuthenticationType = "ApplicationCookie";
            options.LoginPath = new PathString("/Auth/Login");
            app.UseCookieAuthentication(options);
        }
    }
}
