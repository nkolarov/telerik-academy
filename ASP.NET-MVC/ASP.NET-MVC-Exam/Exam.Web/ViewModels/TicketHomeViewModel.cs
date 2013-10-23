using Exam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Exam.Web.ViewModels
{
    public class TicketHomeViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [DisplayName("Category")]
        public string CategoryName { get; set; }

        [DisplayName("Author")]
        public string AuthorName { get; set; }

        public int CommentsCount { get; set; }

        public Priority Priority { get; set; }

        [DisplayName("Priority")]
        public string PriorityString
        {
            get
            {
                return this.Priority.ToString();
            }
        }
    }
}