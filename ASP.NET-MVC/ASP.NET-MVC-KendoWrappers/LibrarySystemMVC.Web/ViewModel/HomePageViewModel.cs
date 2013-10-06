using Kendo.Mvc.UI;
using LibrarySystemMVC.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarySystemMVC.Web.Models
{
    public class HomePageViewModel
    {
        public IEnumerable<TreeViewItemModel> TreeViewData { get; set; }
        public IEnumerable<BookDetailsViewModel> BooksDetails { get; set; }
    }
}