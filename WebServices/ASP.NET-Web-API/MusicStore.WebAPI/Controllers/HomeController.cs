using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Data;
using MusicStore.Data.Migrations;


namespace MusicStore.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicStoreContext, Configuration>());

            return View();
        }
    }
}
