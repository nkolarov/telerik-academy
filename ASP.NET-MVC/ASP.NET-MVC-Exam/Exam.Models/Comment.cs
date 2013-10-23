using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Exam.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "The Content length must be between {2} and {1} symbols.")]
        public string Content { get; set; }
    }
}
