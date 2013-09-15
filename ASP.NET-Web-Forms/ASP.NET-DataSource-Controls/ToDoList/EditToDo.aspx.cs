using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToDoList
{
    public partial class EditToDo : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            int? toDoId = Convert.ToInt32(Request.Params["toDoId"]);

            if (toDoId != null && toDoId > 0)
            {
                ToDoListEntities context = new ToDoListEntities();
                ToDo toDo = context.ToDos.Find(toDoId);
                this.ListBoxCategories.DataSource = context.Categories.ToList();
                this.ListBoxCategories.DataTextField = "Name";
                this.ListBoxCategories.DataValueField = "Id";
                this.ListBoxCategories.DataBind();
                var categoryItem = this.ListBoxCategories.Items.FindByText(toDo.Category.Name);
                categoryItem.Selected = true;
                this.TextBoxToDoTitle.Text = toDo.Title;
                this.TextBoxBody.Text = toDo.Body;
            }
            else
            {
                Response.Redirect("~/ManageToDos.aspx");
            }
        }

        protected void CustomValidatorCategory_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var categoryId = args.Value;
            if (categoryId == "-1")
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }


        protected void CustomValidatorToDoName_ServerValidate(object source, ServerValidateEventArgs args)
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

        protected void CustomValidatorToDoBody_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var nameValue = args.Value;
            if (nameValue.Length > 255)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }


        protected void LinkButtonSaveToDo_Click(object sender, EventArgs e)
        {
            try
            {
                int? toDoId = Convert.ToInt32(Request.Params["toDoId"]);

                if (toDoId != null && toDoId > 0)
                {
                    ToDoListEntities context = new ToDoListEntities();
                    ToDo toDo = context.ToDos.Find(toDoId);

                    if (toDo != null)
                    {
                        toDo.Title = this.TextBoxToDoTitle.Text;
                        toDo.Body = this.TextBoxBody.Text;
                        toDo.CaregoryId = int.Parse(this.ListBoxCategories.SelectedValue);

                        context.SaveChanges();
                        Response.Redirect("~/ManageToDos.aspx");
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