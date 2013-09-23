using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Error_Handler_Control;

namespace LibrarySystem
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LibrarySystemEntities context = new LibrarySystemEntities();
            this.ListViewCategories.DataSource = context.Categories.ToList();
            this.ListViewCategories.DataBind();
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            var queryText = this.TextBoxSearchQuery.Text;
            if ( queryText.Length > 100)
            {
                ErrorSuccessNotifier.AddErrorMessage("Query string length must be less than 100 characters!");
            }
            else
            {
                Response.Redirect("~/Search?q=" + queryText);
            }
        }
    }
}