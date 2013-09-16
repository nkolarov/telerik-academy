using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DetectClientData
{
    public partial class ClientData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ClientBrowserType.Text = "Browser Type: " + Request.UserAgent;
            this.ClientIpAddress.Text = "IP Address: " + Request.UserHostAddress;
        }
    }
}