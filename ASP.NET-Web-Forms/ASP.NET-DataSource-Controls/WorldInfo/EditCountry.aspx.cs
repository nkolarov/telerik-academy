using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WorldInfo
{
    public partial class EditCountry : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            int? countryId = Convert.ToInt32(Request.Params["countryId"]);

            if (countryId != null && countryId > 0)
            {
                WorldInfoEntities context = new WorldInfoEntities();
                Country country = context.Countries.Find(countryId);
                this.ListBoxContinents.DataSource = context.Continents.ToList();
                this.ListBoxContinents.DataTextField = "Name";
                this.ListBoxContinents.DataValueField = "Id";
                this.ListBoxContinents.DataBind();
                var continentItem = this.ListBoxContinents.Items.FindByText(country.Continent.Name);
                continentItem.Selected = true;
                this.TextBoxCountryName.Text = country.Name;
                this.TextBoxLanguage.Text = country.Language;
                this.TextBoxPopulation.Text = country.Population.ToString();
            }
            else
            {
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
            try
            {
                int? countryId = Convert.ToInt32(Request.Params["countryId"]);

                if (countryId != null && countryId > 0)
                {
                    WorldInfoEntities context = new WorldInfoEntities();
                    Country country = context.Countries.Find(countryId);

                    if (country != null)
                    {
                        country.Name = this.TextBoxCountryName.Text;
                        country.Population = long.Parse(this.TextBoxPopulation.Text);
                        country.Language = this.TextBoxLanguage.Text;
                        country.ContinentId = int.Parse(this.ListBoxContinents.SelectedValue);
                        if (this.FileUploadFlag.FileBytes.Length > 0)
                        {
                            country.Flag = this.FileUploadFlag.FileBytes;
                        }

                        if (this.CheckRemoveFlag.Checked)
                        {
                            country.Flag = null;    
                        }

                        context.SaveChanges();
                        Response.Redirect("~/ManageCountries.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                this.LiteralErrorMessage.Visible = true;
                this.LiteralErrorMessage.Text = ex.Message;
            }
        }
    }
}