using SimpleInformationalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleInformationalApp.Controllers
{
    public class GamesController : Controller
    {
        private List<Game> games = new List<Game> { 
            new Game{Id = 1, Title = "Mortal Combat", Description = "One old cool game."},
            new Game{Id = 2, Title = "Street Fighter", Description = "Another old cool game."},
            new Game{Id = 2, Title = "Cadilacs annd dinosaurs", Description = "Another old cool game."}
        };

        public List<Game> Games {
            get {
                return this.games;
            }
        }

        //
        // GET: /Games/
        public ActionResult Index()
        {
            var games = this.Games;
            return View(games);
        }

        public ActionResult GameDetails(int id) 
        {
            var game = this.Games[id];

            return View(game);
        }
	}
}