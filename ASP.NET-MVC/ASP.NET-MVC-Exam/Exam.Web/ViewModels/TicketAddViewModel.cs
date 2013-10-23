using Exam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam.Web.ViewModels
{
    public class TicketAddViewModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        [DisplayName("Category")]
        public string CategoryName { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The title length must be between {2} and {1} symbols.")]
        [StringDoesNotContainsBug(ErrorMessage = "The word 'bug' should not be used in the title!")]
        public string Title { get; set; }

        public int PriorityId { get; set; }

        [DisplayName("Priority")]
        public string PriorityName { get; set; }

        public IEnumerable<SelectListItem> Priorities { get; set; }

        // Optionally
        public string ScreenshotURL { get; set; }

        [DataType(DataType.MultilineText)]
        // Optionally
        public string Description { get; set; }
    }
}