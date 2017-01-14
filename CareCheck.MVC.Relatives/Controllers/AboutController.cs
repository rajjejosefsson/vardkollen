using System.Web.Mvc;

namespace CareCheck.MVC.Relatives.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

    }
}