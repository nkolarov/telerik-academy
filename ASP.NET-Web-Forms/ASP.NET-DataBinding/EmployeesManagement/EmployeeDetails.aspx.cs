using Northwind.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeesManagement
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs ev)
        {
            var employeeIdString = Request.Params["id"];
            int employeID;
            var isPassed = int.TryParse(employeeIdString, out employeID);

            if (isPassed)
            {
                var context = new NorthwindEntities();
                var selectedEmployees = context.Employees.Where(e => e.EmployeeID == employeID).ToList();
                this.DetailsViewEmployee.DataSource = selectedEmployees;
                this.DetailsViewEmployee.DataBind();
            }
        }
    }
}