using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Exam.Web.ViewModels;
using Exam.Models;

namespace Exam.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoriesAdminController : BaseController
    {
        //
        // GET: /CategoriesAdmin/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ReadCategories([DataSourceRequest] DataSourceRequest request)
        {
            var result = this.Data.Categories.All()
                .Select(x => new CategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                });

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel categoryVM)
        {
            var category = this.Data.Categories.GetById(categoryVM.Id);

            if (category.Name != categoryVM.Name)
            {
                category.Name = categoryVM.Name;
            }

            this.Data.SaveChanges();

            return Json(new[] { categoryVM }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel categoryVM)
        {
            if (categoryVM != null)
            {
                Category category = new Category() { Name = categoryVM.Name };
                this.Data.Categories.Add(category);
                this.Data.SaveChanges();
                categoryVM.Id = category.Id;
            }           

            return Json(new[] { categoryVM }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DestroyCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel categoryVM)
        {
            Category category = this.Data.Categories.GetById(categoryVM.Id);
            while (category.Tickets.Count() > 0)
            {
                var ticket = category.Tickets.First();
                while (ticket.Comments.Count() > 0)
                {
                    var comment = ticket.Comments.First();
                    this.Data.Comments.Delete(comment);
                }

                this.Data.Tickets.Delete(ticket);
            }

            this.Data.Categories.Delete(category);

            this.Data.SaveChanges();

            return Json(new[] { categoryVM }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}