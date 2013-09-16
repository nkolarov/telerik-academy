using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloCookie
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserName"];
            if (cookie == null)
            {
                Page.Response.Redirect("Login.aspx");
            }
            else
            {
                this.LiteralWellcome.Text = "Hello " + cookie.Value;
            }
        }
    }
}