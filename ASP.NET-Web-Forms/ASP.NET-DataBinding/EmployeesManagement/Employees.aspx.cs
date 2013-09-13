using Northwind.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeesManagement
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs ev)
        {
            NorthwindEntities context = new NorthwindEntities();

            this.GridViewEmployees.DataSource = context.Employees.ToList();
            this.GridViewEmployees.DataBind();
        }
    }
}