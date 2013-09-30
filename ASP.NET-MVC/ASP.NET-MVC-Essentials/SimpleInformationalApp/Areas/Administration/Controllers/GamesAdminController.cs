using SimpleInformationalApp.Controllers;
using SimpleInformationalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleInformationalApp.Areas.Administration.Controllers
{
    [Authorize]
    public class GamesAdminController : Controller
    {
        private List<Game> allGames;

        public List<Game> AllGames {
            get {
                return this.allGames;
            }
        }

        public GamesAdminController() {
            GamesController games = new GamesController();
            this.allGames = games.Games;
        }
        //
        // GET: /Administration/GamesAdmin/
        public ActionResult Index()
        {
            var games = this.AllGames;
            return View(games);
        }

        public ActionResult Edit(int id) {
            var game = this.AllGames[id];

            return View(game);
        }

        public ActionResult Delete(int id)
        {
            var game = this.AllGames[id];

            return View(game);
        }
	}
}