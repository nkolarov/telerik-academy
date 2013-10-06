using LibrarySystemMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LibrarySystemMVC.Web.ViewModel
{
    public class BookDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime PublishDate { get; set; }

        public string CategoryName { get; set; }

        public static Expression<Func<Book, BookDetailsViewModel>> FromBook {
            get {
                return b => new BookDetailsViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    CategoryName = b.Category.Title,
                    PublishDate = b.PublishDate,
                    Description = b.Description                    
                };
            }
        }
    }
}