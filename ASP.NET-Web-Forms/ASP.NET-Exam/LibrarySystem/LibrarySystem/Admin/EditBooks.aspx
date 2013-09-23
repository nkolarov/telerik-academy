<%@ Page Title="Edit Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBooks.aspx.cs" Inherits="LibrarySystem.Admin.EditBooks" %>

<asp:Content ID="ContentEditBooks" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Books</h1>
    <asp:GridView ID="GridViewBooks" runat="server"
        AutoGenerateColumns="False" DataKeyNames="Id"
        CssClass="gridview"
        PageSize="5" AllowPaging="true" AllowSorting="true"
        ItemType="LibrarySystem.Models.Book"
        SelectMethod="GridViewBooks_GetData"
        DeleteMethod="GridViewBooks_DeleteItem"
        UpdateMethod="GridViewBooks_UpdateItem">
        <Columns>
            <asp:TemplateField HeaderText="Title" SortExpression="Title">
                <ItemTemplate>
                    <%#: Item.Title.ToString().Length>20? (Item.Title as string).Substring(0,17)+"..." : Item.Title  %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Author" SortExpression="Author">
                <ItemTemplate>
                    <%#: Item.Author.ToString().Length>20? (Item.Author as string).Substring(0,17)+"..." : Item.Author  %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ISBN" SortExpression="ISBN">
                <ItemTemplate>
                    <%#: Item.ISBN.ToString().Length>20? (Item.ISBN as string).Substring(0,17)+"..." : Item.ISBN  %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="WebSite" SortExpression="WebSite">
                <ItemTemplate>
                    <a href="<%#: Item.WebSite %>">
                        <%#: Item.WebSite.ToString().Length>20? (Item.WebSite as string).Substring(0,17)+"..." : Item.WebSite  %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category" SortExpression="CategoryId">
                <ItemTemplate>
                    <%#: Item.Category.Title.ToString().Length>20? (Item.Category.Title as string).Substring(0,17)+"..." : Item.Category.Title  %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    Action
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButtonEditBook" runat="server"
                        CssClass="link-button"
                        CommandName="Update"
                        CommandArgument="<%#: Item.Id %>"
                        Text="Edit" />
                    <asp:LinkButton ID="LinkButtonDeleteBook" runat="server"
                        CssClass="link-button"
                        CommandName="Delete"
                        CommandArgument="<%#: Item.Id %>"
                        Text="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Panel runat="server" CssClass="create-link">
        <asp:LinkButton ID="LinkButtonCreateNewBook" runat="server"
            CssClass="link-button"
            Text="Create New"
            OnClick="LinkButtonCreateNewBook_Click" />
    </asp:Panel>
    <asp:Panel ID="PanelCreateBook" runat="server" Visible="false" CssClass="panel">
        <h2>Create New Book</h2>
        <label>
            <span>Title: </span>
            <asp:TextBox ID="TextBoxCreateBookTitle" runat="server" placeholder="Enter book title..." />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCreateBookTitle" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Book title is required!" ControlToValidate="TextBoxCreateBookTitle"></asp:RequiredFieldValidator>
        </label>
        <label>
            <span>Author(s): </span>
            <asp:TextBox ID="TextBoxCreateBookAuthor" runat="server" placeholder="Enter book author / authors ..." />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCreateBookAuthor" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Book author is required!" ControlToValidate="TextBoxCreateBookAuthor"></asp:RequiredFieldValidator>
        </label>
        <label>
            <span>ISBN: </span>
            <asp:TextBox ID="TextBoxCreateBookISBN" runat="server" placeholder="Enter book ISBN ..." />
        </label>
        <label>
            <span>Web site: </span>
            <asp:TextBox ID="TextBoxCreateBookWebSite" runat="server" placeholder="Enter book web site ..." />
        </label>
        <label>
            <span>Description: </span>
            <asp:TextBox ID="TextBoxCreateBookDescription" runat="server" placeholder="Enter book description ..." TextMode="MultiLine" Height="160" />
        </label>
        <label>
            <span>Category: </span>
            <asp:DropDownList ID="DropDownListCreateBookCategory" DataValueField="Id" DataTextField="Title" runat="server" />
        </label>
        <asp:LinkButton ID="LinkButtonSaveBook" runat="server" CssClass="link-button"
            Text="Create" OnClick="LinkButtonSaveBook_Click" />
        <asp:LinkButton ID="LinkButtonCancelCreate" runat="server" CssClass="link-button"
            Text="Cancel" OnClick="LinkButtonCancelCreate_Click" />
    </asp:Panel>
    <asp:Panel ID="PanelEditBook" runat="server" Visible="false" CssClass="panel">
        <h2>Edit Book</h2>
        <asp:HiddenField ID="HiddenFieldEditBookId" runat="server" />
        <label for="TextBoxEditBookTitle">
            <span>Title: </span>
            <asp:TextBox ID="TextBoxEditBookTitle" runat="server" placeholder="Enter book title..." />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEditBookTitle" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Book title is required!" ControlToValidate="TextBoxEditBookTitle"></asp:RequiredFieldValidator>
        </label>
        <label>
            <span>Author(s): </span>
            <asp:TextBox ID="TextBoxEditBookAuthor" runat="server" placeholder="Enter book author / authors ..." />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorBookAuthor" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Book author is required!" ControlToValidate="TextBoxEditBookAuthor"></asp:RequiredFieldValidator>
        </label>
        <label>
            <span>ISBN: </span>
            <asp:TextBox ID="TextBoxEditBookISBN" runat="server" placeholder="Enter book ISBN ..." />
        </label>
        <label>
            <span>Web site: </span>
            <asp:TextBox ID="TextBoxEditBookWebSite" runat="server" placeholder="Enter book web site ..." />
        </label>
        <label>
            <span>Description: </span>
            <asp:TextBox ID="TextBoxEditBookDescription" runat="server" placeholder="Enter book description ..." TextMode="MultiLine" Height="160" />
        </label>
        <label>
            <span>Category: </span>
            <asp:DropDownList ID="DropDownListEditBookCategory" DataValueField="Id" DataTextField="Title" runat="server" />
        </label>
        <asp:LinkButton ID="LinkButtonSaveEditBook" runat="server" CssClass="link-button"
            Text="Save" OnClick="LinkButtonSaveEditBook_Click" />
        <asp:LinkButton ID="LinkButtonCancelEdit" runat="server" CssClass="link-button"
            Text="Cancel" OnClick="LinkButtonCancelEdit_Click" />
    </asp:Panel>
    <asp:Panel ID="PanelDeleteBook" runat="server" Visible="false" CssClass="panel">
        <h2>Confirm Book Deletion?</h2>
        <label>
            Title: 
            <asp:TextBox ID="TextBoxDeleteBookTitle" runat="server" Enabled="false" />
        </label>
        <asp:HiddenField ID="HiddenFieldDeleteBookId" runat="server" />
        <asp:LinkButton ID="LinkButtonDoDelete" runat="server" CssClass="link-button"
            Text="Yes" OnClick="LinkButtonDoDelete_Click" />
        <asp:LinkButton ID="LinkButtonCancelDelete" runat="server" CssClass="link-button"
            Text="No" OnClick="LinkButtonCancelDelete_Click" />
    </asp:Panel>
    <asp:Panel runat="server" CssClass="back-link">
        <asp:HyperLink ID="HyperLinkBack" runat="server" NavigateUrl="~">Back to books</asp:HyperLink>
    </asp:Panel>
</asp:Content>
