using BgTatkoForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BgTatkoForum
{
    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Category> GridViewCategories_GetData()
        {
            BgTatkoEntities context = new BgTatkoEntities();
            return context.Categories.Include("Threads").OrderBy(c=> c.CategoryId);
        }

        protected void LinkButtonCategory_Command(object sender, CommandEventArgs e)
        {
            int categoryId = Convert.ToInt32(e.CommandArgument);
            this.Response.Redirect("Threads.aspx?categoryId=" + categoryId);
        }

        protected void TimerComments_Tick(object sender, EventArgs e)
        {
            this.GridViewCategories.DataBind();
        }
    }
}