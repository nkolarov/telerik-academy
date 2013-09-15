using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WorldInfo
{
    public partial class EditContinent : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            int? continentId = Convert.ToInt32(Request.Params["continentId"]);

            if (continentId != null && continentId > 0)
            {
                WorldInfoEntities context = new WorldInfoEntities();
                Continent continent = context.Continents.Find(continentId);
                this.TextBoxContinentName.Text = continent.Name;
            }
            else
            {
                Response.Redirect("~/ManageContinents.aspx");  
            }
        }

        protected void CustomValidatorContinentName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var nameValue = args.Value;
            if (nameValue.Length > 50)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void LinkButtonSaveQuestion_Click(object sender, EventArgs e)
        {
            try
            {
                int? continentId = Convert.ToInt32(Request.Params["continentId"]);

                if (continentId != null && continentId > 0)
                {
                    WorldInfoEntities context = new WorldInfoEntities();
                    Continent continent = context.Continents.Find(continentId);

                    if (continent != null)
                    {
                        continent.Name = this.TextBoxContinentName.Text;
                        context.SaveChanges();
                        Response.Redirect("~/ManageContinents.aspx");                        
                    }
                }
            }
            catch (Exception ex)
            {
                this.TextBoxErrorMessage.Visible = true;
                this.TextBoxErrorMessage.Text = ex.Message;
            }
        }
    }
}