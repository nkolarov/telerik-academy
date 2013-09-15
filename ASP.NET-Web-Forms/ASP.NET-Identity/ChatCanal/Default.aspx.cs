using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsTemplate
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("User"))
                {
                    Response.Redirect("~/UserArea.aspx");
                }

                if (User.IsInRole("Administrator"))
                {
                    Response.Redirect("~/AdminArea.aspx");
                }

                if (User.IsInRole("Moderator"))
                {
                    Response.Redirect("~/ModeratorArea.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }
    }
}