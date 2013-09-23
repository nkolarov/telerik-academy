using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MenuControl
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuItem[] options = 
            { 
                new MenuItem("Nakov", "http://www.nakov.com"), 
                new MenuItem("TILS", "http://www.telerikacademy.com"),
                new MenuItem("Telerik", "http://www.telerik.com")
            };

            // this.UserMenu.FontColor = "#c0ffee";
            this.UserMenu.DataSource = options;
            this.UserMenu.DataBind();
        }
    }
}