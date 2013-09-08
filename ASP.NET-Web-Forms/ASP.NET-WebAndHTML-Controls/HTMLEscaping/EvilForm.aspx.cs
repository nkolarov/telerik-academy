using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTMLEscaping
{
    public partial class EvilForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var text = this.TextBoxInput.Text;
            var escapedText = Server.HtmlEncode(text);

            this.LabelOutput.Text = escapedText;
            this.TextBoxOutput.Text = text; // The text box escapes the text.
        }
    }
}