using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToDoList
{
    public partial class ManageToDos : System.Web.UI.Page
    {
        protected void LinkButtonCreateNewToDo_Click(object sender, EventArgs e)
        {
            this.sectionCreateToDo.Visible = true;
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
            if (Page.IsValid)
            {
                ToDoListEntities context = new ToDoListEntities();
                ToDo toDo = new ToDo();
                toDo.Title = this.TextBoxToDoTitle.Text;
                toDo.Body = this.TextBoxBody.Text;
                toDo.DateModified = DateTime.Now;
                toDo.CaregoryId = int.Parse(this.ListBoxCategories.SelectedValue);
                context.ToDos.Add(toDo);
                context.SaveChanges();
                Response.Redirect("~/ManageToDos.aspx");
            }
        }

        protected void CustomValidatorCategory_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var continentId = args.Value;
            if (continentId == "-1")
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void LinkButtonDeleteToDo_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var id = int.Parse(e.CommandArgument.ToString());
                ToDoListEntities context = new ToDoListEntities();
                ToDo toDo = context.ToDos.Find(id);
                context.ToDos.Remove(toDo);
                context.SaveChanges();
                Response.Redirect("~/ManageToDos.aspx");
            }
            catch (Exception ex)
            {
                this.LiteralErrorMessage.Visible = true;
                this.LiteralErrorMessage.Text = ex.Message;
            }
        }
    }
}