using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoviesInfo.Models;
using MoviesInfo.Data;
using MoviesInfo.ViewModels;

namespace MoviesInfo.Controllers
{
    public class MoviesController : Controller
    {
        private MoviesContext db = new MoviesContext();

        // GET: /Movies/
        public ActionResult Index()
        {
            return View(db.Movies.Select(MovieViewModel.FromMovie).ToList());
        }

        // GET: /Movies/Create
        public ActionResult Create()
        {
            MovieViewModel movieVM = new MovieViewModel()
            {
                Actors = db.Actors.ToList().Select(actor => new SelectListItem() { Text = actor.Name, Value = actor.Id.ToString() }),
                Actresses = db.Actors.ToList().Select(actor => new SelectListItem() { Text = actor.Name, Value = actor.Id.ToString() }),
            };

            return PartialView("_CreateMovie", movieVM);
        }

        // POST: /Movies/Create
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieViewModel movieVM)
        {
            if (ModelState.IsValid && movieVM != null)
            {
                var actorId = Convert.ToInt32(movieVM.LandingMaleRoleName);
                var actressId = Convert.ToInt32(movieVM.LandingFemaleRoleName);
                Actor leadingActress = new Actor();
                Actor leadingActor = new Actor();

                if (actorId > 0)
                {
                    leadingActor = db.Actors.Find(actorId);
                    if (leadingActor == null)
                    {
                        throw new ArgumentException("Actor does not exists!");
                    }
                }

                if (actressId > 0)
                {
                    leadingActress = db.Actors.Find(actressId);
                    if (leadingActress == null)
                    {
                        throw new ArgumentException("Actress does not exists!");
                    }
                }


                Movie movie = new Movie()
                {
                    Title = movieVM.Title,
                    Year = movieVM.Year,
                    LandingFemaleRole = leadingActress,
                    LandingMaleRole = leadingActor
                };

                db.Movies.Add(movie);
                db.SaveChanges();
                return Content("");
            }

            return PartialView("_CreateMovie", movieVM);
        }

        // GET: /Movies/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Request.IsAjaxRequest())
            {
                MovieViewModel movieVM = db.Movies.Select(MovieViewModel.FromMovie).Single(a => a.Id == id);

                if (movieVM != null)
                {
                    movieVM.Actors = db.Actors.ToList().Select(act => new SelectListItem() { Value = act.Id.ToString(), Text = act.Name });
                    movieVM.Actresses = db.Actors.ToList().Select(act => new SelectListItem() { Value = act.Id.ToString(), Text = act.Name });

                    return PartialView("_EditMovie", movieVM);
                }
                else
                {
                    throw new ArgumentException("Movie does not exists!");
                }
            }

            return View();
        }

        // POST: /Movies/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MovieViewModel movieVM)
        {
            if (ModelState.IsValid && movieVM != null)
            {
                var movie = db.Movies.Find(movieVM.Id);
                if (movie != null)
                {
                    if (movie.Title != movieVM.Title)
                    {
                        movie.Title = movieVM.Title; 
                    }

                    if (movie.Year != movieVM.Year)
                    {
                        movie.Year = movieVM.Year;
                    }

                    if (movie.LandingFemaleRole.Id != movieVM.LandingFemaleRoleId)
                    {
                        movie.LandingFemaleRole = db.Actors.Find(movieVM.LandingFemaleRoleId);
                    }

                    if (movie.LandingMaleRole.Id != movieVM.LandingMaleRoleId)
                    {
                        movie.LandingMaleRole = db.Actors.Find(movieVM.LandingMaleRoleId);
                    }

                    db.SaveChanges();

                    return Content("");
                }
                else
                {
                    throw new ArgumentException("Movie does not exists!");
                }
            }

            return PartialView("_EditMovie", movieVM);
        }

        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MovieViewModel movieVM = db.Movies.Select(MovieViewModel.FromMovie).Single(a => a.Id == id);
            if (movieVM == null)
            {
                return HttpNotFound();
            }

            return PartialView("_DeleteMovie", movieVM);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
