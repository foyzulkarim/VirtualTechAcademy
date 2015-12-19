using System.Web;
using System.Web.Mvc;
using ZooApp.MvcClient.Filters;

namespace ZooApp.MvcClient
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute()); // whole app will require cookie / authenticated request
            filters.Add(new CustomAuthzAttribute());
        }
    }
}
