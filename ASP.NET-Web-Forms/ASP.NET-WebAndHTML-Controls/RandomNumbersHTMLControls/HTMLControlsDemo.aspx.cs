using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomNumbersHTMLControls
{
    public partial class HTMLControlsDemo : System.Web.UI.Page
    {
        private Random rand = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void onButtonGenerateClick(object sender, EventArgs e)
        {
            int firstNumber = int.Parse(this.TextFirstNumber.Value);
            int secondNumber = int.Parse(this.TextSecondNumber.Value);

            int randomNumber = rand.Next(firstNumber, secondNumber + 1);
            this.TextResult.Value = randomNumber.ToString();
        }
        
    }
}