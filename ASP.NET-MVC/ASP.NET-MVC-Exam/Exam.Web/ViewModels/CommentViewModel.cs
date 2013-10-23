using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Web.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public string AuthorUsername { get; set; }

        public string Content { get; set; }
    }
}