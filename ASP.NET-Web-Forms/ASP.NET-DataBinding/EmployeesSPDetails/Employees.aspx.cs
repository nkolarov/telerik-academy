using Northwind.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeesSPDetails
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NorthwindEntities context = new NorthwindEntities();

            this.GridViewEmployees.DataSource = context.Employees.ToList();
            this.GridViewEmployees.DataBind();
        }

        protected void GridViewEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = this.GridViewEmployees.SelectedDataKey.Value;
            NorthwindEntities context = new NorthwindEntities();

            this.FormViewEmployeeDetails.DataSource = context.Employees.Where(emp => emp.EmployeeID == (int)id).ToList();
            this.FormViewEmployeeDetails.DataBind();
        }
    }
}