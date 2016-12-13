using System.Web;
using System.Web.Mvc;

namespace CareCheck.MVC.Relatives
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
