using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Web.ViewModels
{
    public class TicketDetailsViewModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string Title { get; set; }

        public Priority Priority { get; set; }

        public string PriorityString
        {
            get
            {
                return this.Priority.ToString();
            }
        }

        // Optionally
        public string ScreenshotURL { get; set; }

        // Optionally
        public string Description { get; set; }

        public string AuthorName { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}