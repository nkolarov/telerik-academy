using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StringListInSession
{
    public partial class GetData : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["inputText"] != null)
            {
                List<string> dataList = GetDataList();
                this.LiteralEnteredData.Text = Server.HtmlEncode("You have entered: " + string.Join(", ", dataList));
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            var inputData = this.TextBoxData.Text;
            if (!string.IsNullOrEmpty(inputData))
            {
                if (Session["inputText"] != null)
                {
                    List<string> dataList = GetDataList();
                    dataList.Add(inputData);
                    Session["inputText"] = dataList;
                }
                else
                {
                    List<string> dataList = new List<string> { inputData };
                    Session["inputText"] = dataList;
                }
            }
        }

        private List<string> GetDataList()
        {
            var data = Session["inputText"];
            List<string> dataList = (List<string>)data;

            return dataList;
        }
    }
}