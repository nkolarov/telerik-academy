namespace MoviesInfo.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using MoviesInfo.Models;
    using MoviesInfo.Data;
    using MoviesInfo.ViewModels;

    public class ActorsController : Controller
    {
        private MoviesContext db = new MoviesContext();

        // GET: /Actors/
        public ActionResult Index()
        {
            return View(db.Actors.Select(ActorViewModel.FromActor).ToList());
        }


        [HttpGet]
        // GET: /Actors/Create
        public ActionResult Create()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("_CreateActor");
            }

            return View();
        }

        // POST: /Actors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ActorViewModel actorVM)
        {
            if (ModelState.IsValid && actorVM != null)
            {
                Actor actor = new Actor
                {
                    Name = actorVM.Name,
                    Studio = actorVM.Studio,
                    StudioAddress = actorVM.StudioAddress
                };

                db.Actors.Add(actor);
                db.SaveChanges();
                return Content("");
            }

            return PartialView("_CreateActor", actorVM);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Request.IsAjaxRequest())
            {
                ActorViewModel actorVM = db.Actors.Select(ActorViewModel.FromActor).Single( a => a.Id == id);

                if (actorVM != null)
                {
                    return PartialView("_EditActor", actorVM);
                }
                else
                {
                    throw new ArgumentException("Actor does not exists!");
                }
            }

            return View();
        }

        // POST: /Actors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ActorViewModel actorVM)
        {
            if (ModelState.IsValid && actorVM != null)
            {
                var actor = db.Actors.Find(actorVM.Id);
                if (actor != null)
                {
                    if (actor.Name != actorVM.Name)
                    {
                        actor.Name = actorVM.Name;
                    }

                    if (actor.Studio != actorVM.Studio)
                    {
                        actor.Studio = actorVM.Studio;
                    }

                    if (actor.StudioAddress != actorVM.StudioAddress)
                    {
                        actor.StudioAddress = actorVM.StudioAddress;
                    }

                    db.SaveChanges();

                    return Content("");
                }
                else
                {
                    throw new ArgumentException("Actor does not exists!");
                }

            }

            return PartialView("_EditActor", actorVM);
        }

        // GET: /Actors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ActorViewModel actorVM = db.Actors.Select(ActorViewModel.FromActor).Single(a => a.Id == id);

            if (actorVM == null)
            {
                return HttpNotFound();
            }

            return PartialView("_DeleteActor", actorVM);
        }

        // POST: /Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actor actor = db.Actors.Find(id);
            db.Actors.Remove(actor);
            db.SaveChanges();
            return Content("");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
