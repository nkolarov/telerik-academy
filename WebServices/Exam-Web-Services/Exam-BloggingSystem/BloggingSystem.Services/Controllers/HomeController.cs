using System.Web.Mvc;

namespace BloggingSystem.Services.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
