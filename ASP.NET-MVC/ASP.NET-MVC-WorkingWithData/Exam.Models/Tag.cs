using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Exam.Models
{
    public class Tag
    {
        public Tag() 
        {
            this.Tweets = new HashSet<Tweet>();

        }
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Text must be between {2} and {1} symbols")]
        public string Text { get; set; }

        public virtual ICollection<Tweet> Tweets { get; set; }
    }
}
