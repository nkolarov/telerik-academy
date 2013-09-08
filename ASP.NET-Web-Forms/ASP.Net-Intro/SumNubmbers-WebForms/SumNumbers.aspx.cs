using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SumNubmbers_WebForms
{
    public partial class SumNumbers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                decimal firstNumber = decimal.Parse(this.TextBoxFirstNumber.Text);
                decimal secondNumber = decimal.Parse(this.TextBoxSecondNumber.Text);
                decimal sum = firstNumber + secondNumber;

                this.TextBoxSumResult.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                this.TextBoxSumResult.Text = "Error!";
            }
        }
    }
}