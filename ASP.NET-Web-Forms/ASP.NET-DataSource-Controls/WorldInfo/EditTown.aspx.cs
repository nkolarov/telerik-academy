using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WorldInfo
{
    public partial class EditTown : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            int? townId = Convert.ToInt32(Request.Params["townId"]);

            if (townId != null && townId > 0)
            {
                WorldInfoEntities context = new WorldInfoEntities();
                Town town = context.Towns.Find(townId);
                this.ListBoxCountries.DataSource = context.Countries.ToList();
                this.ListBoxCountries.DataTextField = "Name";
                this.ListBoxCountries.DataValueField = "Id";
                this.ListBoxCountries.DataBind();
                var countryItem = this.ListBoxCountries.Items.FindByText(town.Country.Name);
                countryItem.Selected = true;
                this.TextBoxTownName.Text = town.Name;
                this.TextBoxPopulation.Text = town.Population.ToString();
            }
            else
            {
                Response.Redirect("~/ManageTowns.aspx");
            }
        }

        protected void CustomValidatorCountry_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var countryId = args.Value;
            if (countryId == "-1")
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

        protected void CustomValidatorTownName_ServerValidate(object source, ServerValidateEventArgs args)
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

        protected void LinkButtonSaveTown_Click(object sender, EventArgs e)
        {
            try
            {
                int? townId = Convert.ToInt32(Request.Params["townId"]);

                if (townId != null && townId > 0)
                {
                    WorldInfoEntities context = new WorldInfoEntities();
                    Town town = context.Towns.Find(townId);

                    if (town != null)
                    {
                        town.Name = this.TextBoxTownName.Text;
                        town.Population = long.Parse(this.TextBoxPopulation.Text);
                        town.CountryId = int.Parse(this.ListBoxCountries.SelectedValue);
                        context.SaveChanges();
                        Response.Redirect("~/ManageTowns.aspx");
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