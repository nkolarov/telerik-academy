using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Exam.Web.Models;
using Exam.Models;
using Exam.Web.ViewModels;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Exam.Web.Controllers
{
    public class TicketsController : BaseController
    {
        public ActionResult Details(int id)
        {
            var userId = User.Identity.GetUserId();

            var viewModel = this.Data.Tickets.All().Where(x => x.Id == id)
                .Select(x => new TicketDetailsViewModel
                {
                    Id = x.Id,
                    CategoryName = x.Category.Name,
                    Title = x.Title,
                    Priority = x.Priority,
                    ScreenshotURL = x.ScreenshotURL,
                    Description = x.Description,
                    AuthorName = x.Author.UserName,
                    Comments = x.Comments.Select(y => new CommentViewModel { AuthorUsername = y.Author.UserName, Content = y.Content }),
                }).FirstOrDefault();

            return View(viewModel);
        }
        
        [Authorize]
        public ActionResult Add()
        {
            var model = new TicketAddViewModel();
            model.Categories = this.Data.Categories.All().ToList().Select(cat => new SelectListItem() { Text = cat.Name, Value = cat.Id.ToString() });
            model.Priorities = LoadPrioritiesFromEnumeration();
            model.PriorityName = "1";

            return View(model);
        }

        const int PageSize = 5;

        [Authorize]
        private IQueryable<TicketHomeViewModel> GetAllTickets()
        {
            var data = this.Data.Tickets.All().Select(x => new TicketHomeViewModel
            {
                Id = x.Id,
                Title = x.Title,
                CategoryName = x.Category.Name,
                AuthorName = x.Author.UserName,
                CommentsCount = x.Comments.Count(),
                Priority = x.Priority
            }).OrderBy(x => x.Id);

            return data;
        }

        [Authorize]
        public ActionResult Search(string catSearch)
        {
            var result = this.Data.Tickets.All();

            if (catSearch != "Select Category")
            {
                result = result.Where(x => x.Category.Name == catSearch);
            }

            var endResult = result.Select(x => new TicketHomeViewModel
            {
                Id = x.Id,
                Title = x.Title,
                CategoryName = x.Category.Name,
                AuthorName = x.Author.UserName,
                CommentsCount = x.Comments.Count(),
                Priority = x.Priority
            });

            return View(endResult);
        }

        [Authorize]
        public JsonResult GetTickets([DataSourceRequest] DataSourceRequest request)
        {
            return Json(this.GetAllTickets().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(TicketAddViewModel ticketVM)
        {
            if (ModelState.IsValid && ticketVM != null)
            {
                var userId = User.Identity.GetUserId();
                ApplicationUser user = this.Data.Users.All().FirstOrDefault(u => u.Id == userId);
                user.Points = user.Points + 1;
                Ticket ticket = new Ticket();
                ticket.Author = user;
                ticket.Category = this.Data.Categories.GetById(Convert.ToInt32(ticketVM.CategoryName));
                ticket.Priority = (Priority)Convert.ToInt32(ticketVM.PriorityName);
                ticket.ScreenshotURL = ticketVM.ScreenshotURL;
                ticket.Title = ticketVM.Title;
                ticket.Description = ticketVM.Description;

                this.Data.Tickets.Add(ticket);
                this.Data.SaveChanges();

                return RedirectToAction("TicketsList");
            }

            ticketVM.Categories = this.Data.Categories.All().ToList().Select(cat => new SelectListItem() { Text = cat.Name, Value = cat.Id.ToString() });
            ticketVM.Priorities = LoadPrioritiesFromEnumeration();

            return View(ticketVM);
        }

        private static List<SelectListItem> LoadPrioritiesFromEnumeration()
        {
            var priorities = new List<SelectListItem>();

            for (int i = 0; i < Enum.GetValues(typeof(Priority)).Length; i++)
            {
                var item = new SelectListItem
                    {
                        Text = ((Priority)i).ToString(),
                        Value = (i).ToString()
                    };

                if (((Priority)i).ToString() == "Medium")
                {
                    item.Selected = true;
                }

                priorities.Add(item);
            }

            return priorities;
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(SubmitCommentModel commentModel)
        {
            if (ModelState.IsValid)
            {
                var username = this.User.Identity.GetUserName();
                var userId = this.User.Identity.GetUserId();

                this.Data.Comments.Add(new Comment()
                {
                    AuthorId = userId,
                    Content = commentModel.Comment,
                    TicketId = commentModel.TicketId,
                });

                this.Data.SaveChanges();

                var viewModel = new CommentViewModel { AuthorUsername = username, Content = commentModel.Comment };
                return PartialView("_CommentPartial", viewModel);
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }

        [Authorize]
        public ActionResult TicketsList()
        {
            return View();
        }

        [Authorize]
        public JsonResult GetTicketCategoryData()
        {
            var result = this.Data.Categories
                .All()
                .Select(x => new
                {
                    CategoryName = x.Name
                });

            return Json(result, JsonRequestBehavior.AllowGet);
        }
	}
}