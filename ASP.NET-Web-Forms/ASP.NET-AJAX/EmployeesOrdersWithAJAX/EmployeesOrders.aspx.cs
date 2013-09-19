using EmployeesOrdersWithAJAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeesOrdersWithAJAX
{
    public partial class EmployeesOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NorthwindEntities context = new NorthwindEntities();
            this.GridViewEmployees.DataSource = context.Employees.Take(10).ToList();
            this.GridViewEmployees.DataBind();
        }

        protected void GridViewEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            NorthwindEntities context = new NorthwindEntities();
            GridView gridView = (GridView)sender;
            var employeeId = Convert.ToInt32(gridView.SelectedValue);
            Thread.Sleep(2000);
            var orders = context.Orders.Where(emp => emp.EmployeeID == employeeId).Take(10).ToList();
            this.GridViewOrders.DataSource = orders;
            this.GridViewOrders.DataBind();
        }
    }
}