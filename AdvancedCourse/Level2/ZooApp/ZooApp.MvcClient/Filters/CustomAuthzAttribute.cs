using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ZooApp.MvcClient.Models;

namespace ZooApp.MvcClient.Filters
{
    public class CustomAuthzAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorizeCore = base.AuthorizeCore(httpContext);
            if (authorizeCore)
            {
                // logged in user's email is confirmed?
                string username = httpContext.User.Identity.Name;
                // fetch logged in user detail from database
                ApplicationUserManager userManager = httpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationUser user = userManager.FindByName(username);
                return user.EmailConfirmed;
            }
            return false;
        }
    }
}
