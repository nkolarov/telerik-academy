using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Exam.Models
{
    public class Ticket
    {
         private ICollection<Comment> comments;

         public Ticket()
        {
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        [StringLength(100, MinimumLength=3, ErrorMessage="The title length must be between {2} and {1} symbols.")]
        [StringDoesNotContainsBug(ErrorMessage = "The word 'bug' should not be used in the title!")]
        public string Title { get; set; }

        [Required]
        public Priority Priority { get; set; }

        public string ScreenshotURL { get; set; }

        [StringLength(5000, MinimumLength = 3, ErrorMessage = "The description length must be between {2} and {1} symbols.")]
        public string Description { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }

}
