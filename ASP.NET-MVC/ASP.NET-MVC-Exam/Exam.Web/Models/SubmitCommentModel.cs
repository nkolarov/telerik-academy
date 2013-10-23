using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam.Web.Models
{
    public class SubmitCommentModel
    {
        [Required]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "The Content length must be between {2} and {1} symbols.")]
        public string Comment { get; set; }

        [Required]
        public int TicketId { get; set; }
    }
}