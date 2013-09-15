using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WorldInfo
{
    public partial class ManageTowns : System.Web.UI.Page
    {

        protected void LinkButtonCreateNewTown_Click(object sender, EventArgs e)
        {
            this.sectionCreateTown.Visible = true;
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
            if (Page.IsValid)
            {
                WorldInfoEntities context = new WorldInfoEntities();
                Town town = new Town();
                town.Name = this.TextBoxTownName.Text;
                town.Population = long.Parse(this.TextBoxPopulation.Text);
                town.CountryId = int.Parse(this.ListBoxCountries.SelectedValue);
                context.Towns.Add(town);
                context.SaveChanges();
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

        protected void LinkButtonDeleteTown_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var id = int.Parse(e.CommandArgument.ToString());
                WorldInfoEntities context = new WorldInfoEntities();
                Town town = context.Towns.Find(id);
                context.Towns.Remove(town);
                context.SaveChanges();
                Response.Redirect("~/ManageTowns.aspx");
            }
            catch (Exception ex)
            {
                this.LiteralErrorMessage.Visible = true;
                this.LiteralErrorMessage.Text = ex.Message;
            }
        }
    }
}