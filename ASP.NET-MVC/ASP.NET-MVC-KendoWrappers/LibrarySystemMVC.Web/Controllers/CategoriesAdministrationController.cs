using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using LibrarySystemMVC.Data;
using LibrarySystemMVC.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibrarySystemMVC.Models;

namespace LibrarySystemMVC.Web.Controllers
{
    public class CategoriesAdministrationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {

            return View();
        }

        // GET: /BooksAdministration/
        public ActionResult GetAll([DataSourceRequest] DataSourceRequest request)
        {
            var result = db.Categories.Select(CategoryViewModel.FromCategory);

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel categoryVM)
        {

            if (categoryVM != null && ModelState.IsValid)
            {
                var category = new Category
                {
                    Title = categoryVM.Title
                };

                this.db.Categories.Add(category);
                this.db.SaveChanges();

                categoryVM.Id = category.Id;
            }

            return Json(new[] { categoryVM }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel categoryVM)
        {
            Category book = this.db.Categories.FirstOrDefault(x => x.Id == categoryVM.Id);

            if (book != null && ModelState.IsValid)
            {
                if (book.Title != categoryVM.Title)
                {
                    book.Title = categoryVM.Title;
                }

                this.db.SaveChanges();
            }

            return Json((new[] { categoryVM }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DestroyCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel categoryVM)
        {
            var category = this.db.Categories.FirstOrDefault(x => x.Id == categoryVM.Id);

            while (category.Books.Count() > 0)
            {
               this.db.Books.Remove(category.Books.First()); 
            }

            this.db.Categories.Remove(category);
            this.db.SaveChanges();

            return Json(new[] { categoryVM }, JsonRequestBehavior.AllowGet);
        }
	}
}