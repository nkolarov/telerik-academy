using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XMLTreeView
{
    public partial class ArbitaryXML : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TreeViewXML_SelectedNodeChanged(object sender, EventArgs e)
        {
            var selectedValue = this.TreeViewXML.SelectedValue;

            this.LeafInfo.Text = selectedValue;
        }
    }
}