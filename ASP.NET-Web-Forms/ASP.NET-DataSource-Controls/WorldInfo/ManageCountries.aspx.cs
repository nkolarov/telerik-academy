using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WorldInfo
{
    public partial class ManageCountries : System.Web.UI.Page
    {
        protected void LinkButtonCreateNewCountry_Click(object sender, EventArgs e)
        {
            this.sectionCreateCountry.Visible = true;
        }

        protected void CustomValidatorCountryName_ServerValidate(object source, ServerValidateEventArgs args)
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

        protected void LinkButtonSaveCountry_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                WorldInfoEntities context = new WorldInfoEntities();
                Country country = new Country();
                country.Name = this.TextBoxCountryName.Text;
                country.Population = long.Parse(this.TextBoxPopulation.Text);
                country.Language = this.TextBoxLanguage.Text;
                country.ContinentId = int.Parse(this.ListBoxContinents.SelectedValue);
                country.Flag = this.FileUploadFlag.FileBytes;
                context.Countries.Add(country);
                context.SaveChanges();
                Response.Redirect("~/ManageCountries.aspx");
            }
        }

        protected void CustomValidatorContinent_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var continentId = args.Value;
            if (continentId == "-1")
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void CustomValidatorPopulation_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var population = args.Value;
            long populationCount = 0;
            if (long.TryParse(population, out populationCount))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }

        }

        protected void LinkButtonDeleteCountry_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var id = int.Parse(e.CommandArgument.ToString());
                WorldInfoEntities context = new WorldInfoEntities();
                Country country = context.Countries.Find(id);
                context.Towns.RemoveRange(country.Towns);
                context.Countries.Remove(country);
                context.SaveChanges();
                Response.Redirect("~/ManageCountries.aspx");
            }
            catch (Exception ex)
            {
                this.LiteralErrorMessage.Visible = true;
                this.LiteralErrorMessage.Text = ex.Message;
            }
        }
    }
}