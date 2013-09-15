using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WorldInfo
{
    public partial class ManageContinents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButtonCreateNewContinent_Click(object sender, EventArgs e)
        {
            this.sectionCreateContinent.Visible = true;
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
            if (Page.IsValid)
            {
                WorldInfoEntities context = new WorldInfoEntities();
                Continent continent = new Continent();
                continent.Name = this.TextBoxContinentName.Text;
                context.Continents.Add(continent);
                context.SaveChanges();
                Response.Redirect("~/ManageContinents.aspx");
            }
        }

        protected void LinkButtonDeleteContinent_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var id = int.Parse(e.CommandArgument.ToString());
                WorldInfoEntities context = new WorldInfoEntities();
                Continent continent = context.Continents.Find(id);
                context.Towns.RemoveRange(continent.Countries.SelectMany(c => c.Towns));
                context.Countries.RemoveRange(continent.Countries);
                context.Continents.Remove(continent);
                context.SaveChanges();
                Response.Redirect("~/ManageContinents.aspx");
            }
            catch (Exception ex)
            {
                this.LiteralErrorMessage.Visible = true;
                this.LiteralErrorMessage.Text = ex.Message;
            }
        }
    }
}