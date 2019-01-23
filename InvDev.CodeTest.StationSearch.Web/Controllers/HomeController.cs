using System.Web.Mvc;

namespace InvDev.CodeTest.StationSearch.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Train Station Finder";

            return View();
        }
    }
}
