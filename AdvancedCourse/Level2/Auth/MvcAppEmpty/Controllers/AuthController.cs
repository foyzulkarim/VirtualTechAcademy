using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using MvcAppEmpty.Models;

namespace MvcAppEmpty.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Email.Length>0 && model.Password.Length>0)
            {
                // cred. are ok. now do the sign in
                /*         
            get the authentication manager
            create a claim    
            create claimsidentity
            signin by manager and claimsidentity
            */

                IOwinContext context = Request.GetOwinContext();
                IAuthenticationManager manager = context.Authentication;


                var claims = new List<Claim>();
               claims.Add(new Claim(ClaimTypes.Email,model.Email));
                claims.Add(new Claim(ClaimTypes.Name, "Foyzul"));
                claims.Add(new Claim("Test", "Test@"+DateTime.Now));
                ClaimsIdentity identity = new ClaimsIdentity(claims:claims, authenticationType:"ApplicationCookie");
                manager.SignIn(identities: identity);
                return Redirect("/");
            }
            return View(model);

        }
    }
}