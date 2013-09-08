using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWebForms
{
    public partial class SayHello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var name = this.TextBoxName.Text;
            this.TextBoxResult.Text = "Hello " + name + "!";
;
        }
    }
}