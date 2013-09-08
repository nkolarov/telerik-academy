using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomNumbersWebServerControls
{
    public partial class WebServerControlsDemo : System.Web.UI.Page
    {
        private Random rand = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int minNumber = int.Parse(this.TextBoxMin.Text);
            int maxNumber = int.Parse(this.TextBoxMax.Text);

            int randomNumber = rand.Next(minNumber, maxNumber + 1);
            this.TextBoxRandom.Text = randomNumber.ToString();
        
        }
    }
}