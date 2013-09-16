using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloCookie
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserName"];
            if (cookie != null)
            {
                Page.Response.Redirect("Home.aspx");
            }

        }

        protected void ButtonLogMeIn_Click(object sender, EventArgs e)
        {
            var userName = this.TextUserName.Text;
            HttpCookie cookie = new HttpCookie("UserName", userName);
            cookie.Expires = DateTime.Now.AddMinutes(1);

            Response.Cookies.Add(cookie);
        }
    }
}