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
    public partial class EditBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<LibrarySystem.Models.Book> GridViewBooks_GetData()
        {
            LibrarySystemEntities context = new LibrarySystemEntities();

            return context.Books.Include("Category").OrderBy(c => c.Id);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewBooks_DeleteItem(int id)
        {
            LibrarySystemEntities context = new LibrarySystemEntities();
            var book = context.Books.Find(id);
            HideAllPanels();
            this.HiddenFieldDeleteBookId.Value = id.ToString();
            this.TextBoxDeleteBookTitle.Text = book.Title;
            this.PanelDeleteBook.Visible = true;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewBooks_UpdateItem(int id)
        {
            LibrarySystemEntities context = new LibrarySystemEntities();
            var book = context.Books.Find(id);
            InitializeEditPanel(id, context, book);
            HideAllPanels();
            this.PanelEditBook.Visible = true;
        }

        protected void LinkButtonCreateNewBook_Click(object sender, EventArgs e)
        {
            LibrarySystemEntities context = new LibrarySystemEntities();
            ClearCreatePanelFields();
            HideAllPanels();
            this.DropDownListCreateBookCategory.DataSource = context.Categories.ToList();
            this.DropDownListCreateBookCategory.DataBind();
            this.PanelCreateBook.Visible = true;
        }

        protected void LinkButtonCancelCreate_Click(object sender, EventArgs e)
        {
            HideAllPanels();
        }

        protected void LinkButtonSaveBook_Click(object sender, EventArgs e)
        {
            try
            {
                LibrarySystemEntities context = new LibrarySystemEntities();
                Book book = new Book();
                book.Title = this.TextBoxCreateBookTitle.Text;
                book.Author = this.TextBoxCreateBookAuthor.Text;
                book.ISBN = this.TextBoxCreateBookISBN.Text;
                book.WebSite = this.TextBoxCreateBookWebSite.Text;
                book.Description = this.TextBoxCreateBookDescription.Text;
                book.CategoryId = Convert.ToInt32(this.DropDownListCreateBookCategory.SelectedValue);
                context.Books.Add(book);
                context.SaveChanges();
                HideAllPanels();
                this.GridViewBooks.DataBind();
                HideAllPanels();

                ErrorSuccessNotifier.AddSuccessMessage("Book created.");
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
                var bookId = Convert.ToInt32(this.HiddenFieldDeleteBookId.Value);
                var book = context.Books.Find(bookId);
                context.Books.Remove(book);
                context.SaveChanges();
                HideAllPanels();
                this.GridViewBooks.DataBind();
                ErrorSuccessNotifier.AddSuccessMessage("Book deleted.");
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

        protected void LinkButtonSaveEditBook_Click(object sender, EventArgs e)
        {
            try
            {
                LibrarySystemEntities context = new LibrarySystemEntities();
                var bookId = Convert.ToInt32(this.HiddenFieldEditBookId.Value);
                var book = context.Books.Find(bookId);
                book.Title = this.TextBoxEditBookTitle.Text;
                book.Author = this.TextBoxEditBookAuthor.Text;
                book.ISBN = this.TextBoxEditBookISBN.Text;
                book.WebSite = this.TextBoxEditBookWebSite.Text;
                book.Description = this.TextBoxEditBookDescription.Text;
                book.CategoryId = Convert.ToInt32(this.DropDownListEditBookCategory.SelectedValue);
                context.SaveChanges();
                HideAllPanels();
                this.GridViewBooks.DataBind();
                ErrorSuccessNotifier.AddSuccessMessage("Book modified.");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        protected void LinkButtonCancelEdit_Click(object sender, EventArgs e)
        {
            HideAllPanels();
        }

        private void HideAllPanels()
        {
            this.PanelCreateBook.Visible = false;
            this.PanelDeleteBook.Visible = false;
            this.PanelEditBook.Visible = false;
            this.LinkButtonCreateNewBook.Visible = true;
        }

        private void ClearCreatePanelFields()
        {
            this.TextBoxCreateBookTitle.Text = "";
            this.TextBoxCreateBookAuthor.Text = "";
            this.TextBoxCreateBookISBN.Text = "";
            this.TextBoxCreateBookWebSite.Text = "";
            this.TextBoxCreateBookDescription.Text = "";
        }

        private void InitializeEditPanel(int id, LibrarySystemEntities context, Book book)
        {
            this.PanelCreateBook.Visible = false;
            this.PanelDeleteBook.Visible = false;
            this.LinkButtonCreateNewBook.Visible = false;
            this.HiddenFieldEditBookId.Value = id.ToString();
            this.TextBoxEditBookTitle.Text = book.Title;
            this.TextBoxEditBookAuthor.Text = book.Author;
            this.TextBoxEditBookISBN.Text = book.ISBN;
            this.TextBoxEditBookWebSite.Text = book.WebSite;
            this.TextBoxEditBookDescription.Text = book.Description;
            this.DropDownListEditBookCategory.DataSource = context.Categories.ToList();
            this.DropDownListCreateBookCategory.SelectedValue = book.CategoryId.ToString();
            this.DropDownListEditBookCategory.DataBind();
            var categoryItem = this.DropDownListEditBookCategory.Items.FindByText(book.Category.Title);
            categoryItem.Selected = true;
        }
    }
}