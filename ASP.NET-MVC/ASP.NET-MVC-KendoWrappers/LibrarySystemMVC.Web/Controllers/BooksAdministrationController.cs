using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibrarySystemMVC.Web.ViewModel;
using LibrarySystemMVC.Data;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using LibrarySystemMVC.Models;

namespace LibrarySystemMVC.Web.Controllers
{
    public class BooksAdministrationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewData["categories"] = db.Categories.Select(CategoryViewModel.FromCategory);

            return View();
        }

        // GET: /BooksAdministration/
        public ActionResult GetAll([DataSourceRequest] DataSourceRequest request)
        {
            var result = db.Books.Select(BookDetailsViewModel.FromBook);

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateBook([DataSourceRequest] DataSourceRequest request, BookDetailsViewModel bookVM)
        {
            if (bookVM.CategoryName == null)
            {
                ModelState.AddModelError("CategoryName", "You must select category");
            }

            if (bookVM != null && ModelState.IsValid)
            {
                var catTitle = bookVM.CategoryName;
                var category = this.db.Categories.FirstOrDefault(x => x.Title == catTitle);

                var book = new Book
                {
                    Title = bookVM.Title,
                    Description = bookVM.Description,
                    Author = bookVM.Author,
                    PublishDate = bookVM.PublishDate,
                    Category = category
                };

                this.db.Books.Add(book);
                this.db.SaveChanges();

                bookVM.Id = book.Id;
            }

            return Json(new[] { bookVM }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateBook([DataSourceRequest] DataSourceRequest request, BookDetailsViewModel bookVM)
        {
            Book book = this.db.Books.FirstOrDefault(x => x.Id == bookVM.Id);

            if (book != null && ModelState.IsValid)
            {
                if (book.Title != bookVM.Title)
                {
                    book.Title = bookVM.Title;
                }

                if (book.Description != bookVM.Description)
                {
                    book.Description = bookVM.Description; 
                }

                if (book.Author != bookVM.Author)
                {
                    book.Author = bookVM.Author; 
                }

                if (book.PublishDate != bookVM.PublishDate)
                {
                    book.PublishDate = bookVM.PublishDate;
                }

                if (book.Category.Title != bookVM.CategoryName)
                {
                    book.Category = this.db.Categories.Where(x => x.Title == bookVM.CategoryName).Single();
                }                

                this.db.SaveChanges();
            }

            return Json((new[] { bookVM }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DestroyBook([DataSourceRequest] DataSourceRequest request, BookDetailsViewModel bookVM)
        {
            var book = this.db.Books.FirstOrDefault(x => x.Id == bookVM.Id);

            this.db.Books.Remove(book);
            this.db.SaveChanges();

            return Json(new[] { bookVM }, JsonRequestBehavior.AllowGet);
        }
    }
}
