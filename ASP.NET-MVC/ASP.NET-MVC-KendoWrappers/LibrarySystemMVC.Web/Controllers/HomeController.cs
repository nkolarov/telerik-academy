using Kendo.Mvc.UI;
using LibrarySystemMVC.Data;
using LibrarySystemMVC.Models;
using LibrarySystemMVC.Web.Models;
using LibrarySystemMVC.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystemMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var homeVM = new HomePageViewModel();

            homeVM.TreeViewData = db.Categories.ToList().Select(x => new TreeViewItemModel
               {
                   Text = x.Title,
                   HasChildren = db.Books.Where(b => b.Category.Title == x.Title).Count() > 0,
                   Items = db.Books.Where(b => b.Category.Title == x.Title).ToList()
                   .Select(y => new TreeViewItemModel
                   {
                       Text = y.Title,
                       Url = "/Home/BookDetails/" + y.Id
                   })
                       .ToList()
               });

            homeVM.BooksDetails = db.Books.Select(BookDetailsViewModel.FromBook);

            return View(homeVM);
        }

        public ActionResult BookDetails(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var bookVM = db.Books.Where(b => b.Id == id).Select(BookDetailsViewModel.FromBook).Single();

            return View(bookVM);
        }

        public ActionResult Search(string queryString)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var bookVM = db.Books.Where(b => b.Title.ToLower().Contains(queryString.ToLower()) || b.Description.ToLower().Contains(queryString.ToLower())).Select(BookDetailsViewModel.FromBook);

            return View(bookVM);
        }
    }
}