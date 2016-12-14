using System.Web.Mvc;

namespace CareCheck.MVC.Admin.Controllers.Other
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}