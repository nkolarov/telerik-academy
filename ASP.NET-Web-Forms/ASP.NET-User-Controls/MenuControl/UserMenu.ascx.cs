using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MenuControl
{
    [System.ComponentModel.DefaultBindingProperty("DataSource")]
    public partial class UserMenu : System.Web.UI.UserControl
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.DataListUserMenu.Style.Add("font-family", this.FontFamily);
        }

        public UserMenu()
        {
            this.FontFamily = "Comic Sans MS";
            this.FontColor = "black";
        }

        public string FontFamily { get; set; }

        public string FontColor { get; set; }

        public IEnumerable<MenuItem> DataSource
        {
            get { return (IEnumerable<MenuItem>)this.DataListUserMenu.DataSource; }
            set
            {
                foreach (var item in value)
                {
                    if (string.IsNullOrWhiteSpace(item.FontColor))
                    {
                        item.FontColor = this.FontColor;
                    }
                }

                this.DataListUserMenu.DataSource = value;
            }
        }



        public override void DataBind()
        {
            this.DataListUserMenu.DataBind();

            base.DataBind();
        }
    }

}