using BgTatkoForum.Models;
using Error_Handler_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BgTatkoForum.Admin
{
    public partial class EditThreads : System.Web.UI.Page
    {
        IQueryable<BgTatkoForum.Models.Thread> threads =
            new BgTatkoEntities().Threads.Include("User").OrderByDescending(t => t.DateCreated);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<BgTatkoForum.Models.Thread> GridViewEditThreads_GetData()
        {
            return threads;
        }

        protected void LinkButtonDelete_Command(object sender, CommandEventArgs e)
        {
            this.FormViewDeleteThread.Visible = true;
            int threadId = Convert.ToInt32(e.CommandArgument);
            BgTatkoEntities context = new BgTatkoEntities();
            var thread = context.Threads.Where(t=> t.ThreadId == threadId).ToList();
            this.FormViewDeleteThread.DataSource = thread;
            this.FormViewDeleteThread.DataBind();
        }

        protected void LinkButtonDeleteThread_Command(object sender, CommandEventArgs e)
        {
            try
            {
                BgTatkoEntities context = new BgTatkoEntities();
                int threadId = Convert.ToInt32(e.CommandArgument);
                var thread = context.Threads.Where(t => t.ThreadId == threadId).FirstOrDefault();
                context.Posts.RemoveRange(thread.Posts);
                context.ThreadVotes.RemoveRange(thread.ThreadVotes);
                context.Threads.Remove(thread);
                context.SaveChanges();
                this.GridViewEditThreads.DataBind();
                ErrorSuccessNotifier.AddSuccessMessage("Thread deleted");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            this.FormViewDeleteThread.Visible = false;
        }

        protected void LinkButtonCancelDelete_Command(object sender, CommandEventArgs e)
        {
            this.FormViewDeleteThread.Visible = false;
        }
       

    }
}