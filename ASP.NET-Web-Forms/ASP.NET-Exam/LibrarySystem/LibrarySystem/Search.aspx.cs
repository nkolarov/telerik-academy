using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var queryString = Request.Params["q"];
            this.SearchHeader.InnerText = "Search Results for Query “" + queryString + "”:";
            List<Book> books = new List<Book>();

            if (!string.IsNullOrEmpty(queryString))
            {
                LibrarySystemEntities context = new LibrarySystemEntities();

                books = context.Books.Where(b => b.Title.Contains(queryString) || b.Author.Contains(queryString)).OrderBy(b => b.Title).ThenBy( b=> b.Author).ToList();
            }
            else
            {
                LibrarySystemEntities context = new LibrarySystemEntities();
                books = context.Books.OrderBy(b => b.Title).ThenBy(b => b.Author).ToList();
            }

            this.ListViewSearch.DataSource = books;
            this.DataBind();
        }
    }
}