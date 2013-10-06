using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class Tweet
    {
        public Tweet() 
        {
            this.Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Text must be between {2} and {1} symbols")]
        public string Text { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime DatePosted { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
