using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrintExecutingPath
{
    public partial class DemoForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Response.Write("Hello! I am C#");
            var assembly = Assembly.GetExecutingAssembly();
            this.Response.Write("<br />Executing assembly name: " + assembly.FullName + "; Path: " + assembly.Location);
        }
    }
}