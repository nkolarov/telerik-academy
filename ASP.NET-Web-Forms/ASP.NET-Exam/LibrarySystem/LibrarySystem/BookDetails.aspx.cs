using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class BookDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var bookIdString = Request.Params["id"];
            int bookId;

            if (int.TryParse(bookIdString, out bookId) && bookId > 0)
            {
                LibrarySystemEntities context = new LibrarySystemEntities();
                var book = context.Books.Where(b => b.Id == bookId).ToList();
                if (book != null)
                {
                    this.FormViewBooks.DataSource = book;
                    this.FormViewBooks.DataBind();
                }
                else
                {
                    Response.Redirect("~/");
                }
            }
            else
            {
                Response.Redirect("~/");
            }
        }
    }
}