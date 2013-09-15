using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToDoList
{
    public partial class EditCategory : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            int? CategoryId = Convert.ToInt32(Request.Params["CategoryId"]);

            if (CategoryId != null && CategoryId > 0)
            {
                ToDoListEntities context = new ToDoListEntities();
                Category Category = context.Categories.Find(CategoryId);
                this.TextBoxCategoryName.Text = Category.Name;
            }
            else
            {
                Response.Redirect("~/ManageCategories.aspx");
            }
        }

        protected void CustomValidatorCategoryName_ServerValidate(object source, ServerValidateEventArgs args)
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

        protected void LinkButtonSaveQuestion_Click(object sender, EventArgs e)
        {
            try
            {
                int? categoryId = Convert.ToInt32(Request.Params["CategoryId"]);

                if (categoryId != null && categoryId > 0)
                {
                    ToDoListEntities context = new ToDoListEntities();
                    Category Category = context.Categories.Find(categoryId);

                    if (Category != null)
                    {
                        Category.Name = this.TextBoxCategoryName.Text;
                        context.SaveChanges();
                        Response.Redirect("~/ManageCategories.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                this.TextBoxErrorMessage.Visible = true;
                this.TextBoxErrorMessage.Text = ex.Message;
            }
        }
    }
}