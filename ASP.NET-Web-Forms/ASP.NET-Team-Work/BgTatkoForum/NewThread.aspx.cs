using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BgTatkoForum.Models;
using Error_Handler_Control;

namespace BgTatkoForum
{
    public partial class NewThread : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!this.User.Identity.IsAuthenticated)
	        {
                this.Response.Redirect("Account/Login.aspx");
	        }
            else
            {
                BgTatkoEntities context = new BgTatkoEntities();
                var categories = context.Categories.ToList();
                this.DropDownListCategory.DataSource = categories;
                this.DropDownListCategory.SelectedIndex = 0;
                this.DropDownListCategory.DataBind();
            }
        }

        protected void LinkButtonSaveThread_Click(object sender, EventArgs e)
        {
            try
            {
                BgTatkoEntities context = new BgTatkoEntities();
                BgTatkoForum.Models.Thread thread = new BgTatkoForum.Models.Thread();
                thread.Content = this.TextBoxContent.Text;
                thread.Title = this.TextBoxTitle.Text;
                thread.DateCreated = DateTime.Now;
                thread.CategoryId = this.DropDownListCategory.SelectedIndex + 1;
                var user = context.Users.Where(u => u.UserName == this.User.Identity.Name).FirstOrDefault();
                thread.Category = context.Categories.Find(thread.CategoryId);
                thread.User = user;
                thread.UserId = user.Id;
                context.Threads.Add(thread);
                user.Threads.Add(thread);
                context.SaveChanges();

                var titleTokens = this.TextBoxTitle.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var textBoxTokens = this.TextBoxTags.Text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                var tokens = textBoxTokens.Union(titleTokens);

                foreach (var token in tokens)
                {
                    var existingTag = context.Tags.FirstOrDefault(t => t.Name == token.ToLower());

                    if (existingTag != null)
                    {
                        existingTag.Threads.Add(thread);
                        context.SaveChanges();
                    }
                    else
                    {
                        var newTag = new Tag() { Name = token.ToLower() };
                        context.Tags.Add(newTag);
                        context.SaveChanges();
                        newTag.Threads.Add(thread);
                        context.SaveChanges();
                    }
                }

                this.Response.Redirect("Thread/Thread?threadId=" + thread.ThreadId, false);
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
            
        }
    }
}