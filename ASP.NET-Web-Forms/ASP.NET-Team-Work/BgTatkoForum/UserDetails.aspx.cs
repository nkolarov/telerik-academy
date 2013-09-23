using BgTatkoForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BgTatkoForum
{
    public partial class UserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["userId"];
            var tatko = new BgTatkoEntities().Users.Include("UserDetail")
                            .FirstOrDefault(use => use.Id == id);
            UserDisplayModel userDetails = new UserDisplayModel()
            {
                Id = tatko.Id,
                DisplayName = tatko.UserName,
                FullName = "(none)",
                Member = 0,
                User = new User()
                {
                    Threads = tatko.Threads,
                    Comments = tatko.Comments,
                    Posts = tatko.Posts
                },
                Avatar = null,
                UserDetails = new UserDetail()
                {
                    WebSite = "(none)",
                    About = "(none)"
                },
                Score = (tatko.Threads.Count + tatko.ThreadVotes.Count) * 10 +
                        (tatko.Posts.Count + tatko.PostVotes.Count) * 5 +
                        (tatko.Comments.Count) * 1
            };

            if (tatko.UserDetail != null)
            {
                userDetails.FullName = tatko.UserDetail.FirstName + " " + tatko.UserDetail.LastName;
                userDetails.Member = (DateTime.Now - tatko.UserDetail.DateRegistered).Days;
                userDetails.Avatar = tatko.UserDetail.Avatar;
                userDetails.UserDetails = new UserDetail()
                {
                    WebSite = tatko.UserDetail.WebSite,
                    About = tatko.UserDetail.About
                };
            }

            this.FormViewUserDetails.DataSource = new List<UserDisplayModel>() { userDetails };

            this.ListViewPosts.DataSource = tatko.Posts.ToList();
            this.DataBind();
        }

        protected void Avatar_PreRender(object sender, EventArgs e)
        {
            var image = (Image)sender;
            var userId = this.Request.Params["userId"];
            image.ImageUrl = "~/ImageHandler.ashx?userId=" + userId; //new BgTatkoEntities().UserDetails.Include("Users").
        }

        protected void Thread_Command(object sender, CommandEventArgs e)
        {
            int threadId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("~/Thread.aspx?threadId=" + threadId);
        }

        protected void Category_Command(object sender, CommandEventArgs e)
        {
            int categoryId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("~/Thread.aspx?categoryId=" + categoryId);
        }
    }
}