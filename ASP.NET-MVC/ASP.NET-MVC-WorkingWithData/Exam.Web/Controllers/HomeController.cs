using Exam.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Exam.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            UowData uowData = new UowData();

            var userId = User.Identity.GetUserId();
            var tweets = uowData.Tweets.All().Where(t => t.AuthorId == userId);

            return View(tweets);
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SearchByTag(string tag)
        {
            UowData uowData = new UowData();

            var key = "SearchByTag-" + tag;
            if (this.HttpContext.Cache[key] == null)
            {
                var tweets = uowData.Tweets.All().Where(t => t.Tags.Any(ta => ta.Text.ToLower().Contains(tag.ToLower()))).ToList();
                this.HttpContext.Cache.Add(key, tweets, null, DateTime.Now.AddMinutes(15), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            }

            return PartialView("_SearchResults", this.HttpContext.Cache[key]);
        }
    }
}