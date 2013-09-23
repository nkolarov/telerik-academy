using BgTatkoForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BgTatkoForum
{
    public partial class Tags : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Tag> GridViewTags_GetData()
        {
            BgTatkoEntities context = new BgTatkoEntities();
            return context.Tags.Include("Threads").OrderByDescending(t => t.Threads.Count);
        }

        protected void LinkButtonTag_Command(object sender, CommandEventArgs e)
        {
            int tagId = Convert.ToInt32(e.CommandArgument);
            this.Response.Redirect("Threads.aspx?tagId=" + tagId);
        }

        protected void TimerComments_Tick(object sender, EventArgs e)
        {
            this.GridViewTags.DataBind();
        }
    }
}