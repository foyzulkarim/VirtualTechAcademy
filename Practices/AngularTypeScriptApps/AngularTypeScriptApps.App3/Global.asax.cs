using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.SessionState;

namespace AngularTypeScriptApps.App3
{
    public class Global : System.Web.HttpApplication
    {
        private void Register(HttpConfiguration config)
        {
            config.Formatters.Clear(); 
            config.Formatters.Add(new JsonMediaTypeFormatter());
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        protected void Application_Start(object sender, EventArgs e)
        {         
            GlobalConfiguration.Configure(Register);
        }        
    }
}