using BgTatkoForum.Models;
using Error_Handler_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BgTatkoForum.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.User.IsInRole("Admin"))
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {

        }

        private IQueryable<User> threads = GetUsersData();

        private static IQueryable<User> GetUsersData()
        {
            var context = new BgTatkoEntities();
            var users = context.Users;
            var usersDetails = context.UserDetails;
            var usersRols = context.UserRoles;


            return users;
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<BgTatkoForum.Models.User> GridViewUsers_GetData()
        {
            return this.threads;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewUsers_UpdateItem(string id)
        {
            try
            {
                BgTatkoEntities context = new BgTatkoEntities();
                User item = context.Users.Find(id);
                // Load the item here, e.g. item = MyDataLayer.Find(id);
                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                    return;
                }
                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    // Save changes here, e.g. MyDataLayer.SaveChanges();
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewUsers_DeleteItem(string id)
        {
            BgTatkoEntities context = new BgTatkoEntities();
            User item = context.Users.Find(id);
            context.Users.Remove(item);
            context.SaveChanges();
        }
        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<BgTatkoForum.Models.User> GridViewUserDetails_GetData()
        {
            return null;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewUserDetails_UpdateItem(int id)
        {
            BgTatkoForum.Models.User item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();

            }
        }
    }
}