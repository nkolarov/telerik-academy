using SearchCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SearchCars
{
    public partial class SearchCar : System.Web.UI.Page
    {
        private List<Producer> producers;
        private List<Extra> extras;
        private string[] engines;

        protected void Page_Load(object sender, EventArgs ev)
        {
            LoadProducersData();
            if (!Page.IsPostBack)
            {
                this.DropDownListProducer.DataSource = producers.Select(p => p.Name);
                this.CheckBoxListExtras.DataSource = extras.Select(e => e.Name);
                this.RadioButtonListEngines.DataSource = engines;
                this.DataBind();
            }
        }

        private void LoadProducersData()
        {
            extras = new List<Extra> { 
                new Extra{ Name = "Central locking" },
                new Extra{ Name = "Auxiliary heating" },
                new Extra{ Name = "Cruise control" },
                new Extra{ Name = "Electric heated seats" },
                new Extra{ Name = "Electric windows" }
            };

            var audiModels = new List<Model>{
                new Model{ Name = "A2" },
                new Model{ Name = "A3" },
                new Model{ Name = "A4" },
                new Model{ Name = "A5" },
                new Model{ Name = "A6" },
                new Model{ Name = "A7" },
                new Model{ Name = "A8" },
            };

            var bmwModels = new List<Model>{
                new Model{ Name = "3 series" },
                new Model{ Name = "5 series" },
                new Model{ Name = "7 series" }
            };

            producers = new List<Producer> {
                new Producer{ Name = "AUDI", Models = audiModels },
                new Producer{ Name = "BMW", Models = bmwModels },
            };

            engines = new[] { "Petrol", "Diesel" };
        }

        protected void DropDownListProducer_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedProducer =  producers.FirstOrDefault( p => p.Name == this.DropDownListProducer.SelectedValue);
            if (selectedProducer != null)
            {
                this.DropDownListModel.DataSource = selectedProducer.Models.Select(m => m.Name);
                this.DropDownListModel.DataBind();
            }
            else
            {
                this.DropDownListModel.DataSource = new List<Model>();
                this.DropDownListModel.DataBind();
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            var selectedDataText = GetSelectionData();
            this.LiteralSearchData.Text = Server.HtmlEncode(selectedDataText);
        }

        private string GetSelectionData()
        {
            StringBuilder selectedData = new StringBuilder();

            var producer = this.DropDownListProducer.SelectedValue;
            if (producer != "default")
            {
                selectedData.Append("Selected producer: " + producer + "; ");    
            }

            var model = this.DropDownListModel.SelectedValue;
            if (model != null && !string.IsNullOrEmpty(model))
            {
                selectedData.Append("Selected model: " + model + "; ");    
            }

            var engine = this.RadioButtonListEngines.SelectedValue;
            if (engine != null && !string.IsNullOrEmpty(engine))
            {
                selectedData.Append("Selected engine type: " + engine + "; ");    
            }            

            // Get selected extras
            foreach (ListItem extra in this.CheckBoxListExtras.Items)
            {
                if (extra.Selected)
                {
                    selectedData.Append("Selected extra: " + extra.Value + "; ");
                }
            }

            return selectedData.ToString();
        }
    }
}