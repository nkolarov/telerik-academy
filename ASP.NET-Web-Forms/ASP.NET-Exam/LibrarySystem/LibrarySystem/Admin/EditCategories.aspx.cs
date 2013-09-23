using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Error_Handler_Control;

namespace LibrarySystem.Admin
{
    public partial class EditCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCategories_DeleteItem(int id)
        {
            LibrarySystemEntities context = new LibrarySystemEntities();
            var cat = context.Categories.Find(id);
            HideAllPanels();
            this.LinkButtonCreateNewCategory.Visible = false;
            this.HiddenFieldDeleteCategoryId.Value = id.ToString();
            this.TextBoxDeleteCategoryName.Text = cat.Title;
            this.PanelDeleteCategory.Visible = true;
        }

        protected void LinkButtonCreateNewCategory_Click(object sender, EventArgs e)
        {
            this.TextBoxCategoryName.Text = "";
            this.LinkButtonCreateNewCategory.Visible = false;
            this.PanelCreateCategory.Visible = true;
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<LibrarySystem.Models.Category> GridViewCategories_GetData()
        {
            LibrarySystemEntities context = new LibrarySystemEntities();

            return context.Categories.OrderBy(c => c.Id);
        }

        protected void LinkButtonSaveCategory_Click(object sender, EventArgs e)
        {
            try
            {
                LibrarySystemEntities context = new LibrarySystemEntities();
                Category cat = new Category();
                cat.Title = this.TextBoxCategoryName.Text;
                context.Categories.Add(cat);
                context.SaveChanges();
                HideAllPanels();
                this.GridViewCategories.DataBind();
                ErrorSuccessNotifier.AddSuccessMessage("Category created.");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        protected void LinkButtonDoDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LibrarySystemEntities context = new LibrarySystemEntities();
                var catId = Convert.ToInt32(this.HiddenFieldDeleteCategoryId.Value);
                var cat = context.Categories.Find(catId);
                context.Books.RemoveRange(cat.Books); // Remove all books for this caregory
                context.Categories.Remove(cat);
                context.SaveChanges();
                HideAllPanels();
                this.GridViewCategories.DataBind();
                ErrorSuccessNotifier.AddSuccessMessage("Category deleted.");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        protected void LinkButtonCancelDelete_Click(object sender, EventArgs e)
        {
            HideAllPanels();
        }

        protected void LinkButtonCancel_Click(object sender, EventArgs e)
        {
            HideAllPanels();
        }

        protected void LinkButtonCancelEdit_Click(object sender, EventArgs e)
        {
            HideAllPanels();
        }

        protected void LinkButtonEditSave_Click(object sender, EventArgs e)
        {
            try
            {
                LibrarySystemEntities context = new LibrarySystemEntities();
                var catId = Convert.ToInt32(this.HiddenFieldEditCategoryId.Value);
                var cat = context.Categories.Find(catId);
                cat.Title = this.TextBoxEditCategoryName.Text;
                context.SaveChanges();
                HideAllPanels();
                this.GridViewCategories.DataBind();
                ErrorSuccessNotifier.AddSuccessMessage("Category modified.");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCategories_UpdateItem(int id)
        {
            LibrarySystemEntities context = new LibrarySystemEntities();
            var cat = context.Categories.Find(id);
            HideAllPanels();
            this.LinkButtonCreateNewCategory.Visible = false;
            this.HiddenFieldEditCategoryId.Value = id.ToString();
            this.TextBoxEditCategoryName.Text = cat.Title;
            this.PanelEditCategory.Visible = true;
        }

        private void HideAllPanels()
        {
            this.PanelCreateCategory.Visible = false;
            this.PanelEditCategory.Visible = false;
            this.PanelDeleteCategory.Visible = false;
            this.LinkButtonCreateNewCategory.Visible = true;
        }
    }
}