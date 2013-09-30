using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalculator.Models;

namespace WebCalculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new UnitCalculator();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(UnitCalculator model)
        {
            model.ConvertUnits();
            ViewBag.Converted = true;

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
       
    }
}