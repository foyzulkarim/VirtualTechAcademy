using System.Web;
using System.Web.Mvc;

namespace ZooApp.MvcClient
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute()); // whole app will require cookie / authenticated request
        }
    }
}
