using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToDoList
{
    public partial class ManageCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButtonCreateNewCategory_Click(object sender, EventArgs e)
        {
            this.sectionCreateCategory.Visible = true;
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

        protected void LinkButtonSaveCategory_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ToDoListEntities context = new ToDoListEntities();
                Category Category = new Category();
                Category.Name = this.TextBoxCategoryName.Text;
                context.Categories.Add(Category);
                context.SaveChanges();
                Response.Redirect("~/ManageCategories.aspx");
            }
        }

        protected void LinkButtonDeleteCategory_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var id = int.Parse(e.CommandArgument.ToString());
                ToDoListEntities context = new ToDoListEntities();
                Category Category = context.Categories.Find(id);
                context.ToDos.RemoveRange(Category.ToDos);
                context.Categories.Remove(Category);
                context.SaveChanges();
                Response.Redirect("~/ManageCategories.aspx");
            }
            catch (Exception ex)
            {
                this.LiteralErrorMessage.Visible = true;
                this.LiteralErrorMessage.Text = ex.Message;
            }
        }
    }
}