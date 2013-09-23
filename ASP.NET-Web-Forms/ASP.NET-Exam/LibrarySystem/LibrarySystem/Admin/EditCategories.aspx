<%@ Page Title="Edit Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="LibrarySystem.Admin.EditCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Categories</h1>
    <asp:GridView ID="GridViewCategories" runat="server"
        AutoGenerateColumns="False" DataKeyNames="Id"
        CssClass="gridview"
        PageSize="5" AllowPaging="true" AllowSorting="true"
        ItemType="LibrarySystem.Models.Category"
        SelectMethod="GridViewCategories_GetData"
        DeleteMethod="GridViewCategories_DeleteItem"
        UpdateMethod="GridViewCategories_UpdateItem">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Category Name"
                SortExpression="Title" />
            <asp:TemplateField>
                <HeaderTemplate>
                    Action
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButtonEditCategory" runat="server"
                        CssClass="link-button"
                        CommandName="Update"
                        CommandArgument="<%#: Item.Id %>"
                        Text="Edit" />
                    <asp:LinkButton ID="LinkButtonDeleteCategory" runat="server"
                        CssClass="link-button"
                        CommandName="Delete"
                        CommandArgument="<%#: Item.Id %>"
                        Text="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Panel runat="server" CssClass="create-link">
        <asp:LinkButton ID="LinkButtonCreateNewCategory" runat="server"
            CssClass="link-button"
            Text="Create New"
            OnClick="LinkButtonCreateNewCategory_Click" />
    </asp:Panel>
    <asp:Panel ID="PanelCreateCategory" runat="server" Visible="false" CssClass="panel">
        <h2>Create New Category</h2>
        <label>
            Category: 
            <asp:TextBox ID="TextBoxCategoryName" runat="server" placeholder="Enter category name..." />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategoryName" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Category is required!" ControlToValidate="TextBoxCategoryName"></asp:RequiredFieldValidator>
        </label>
        <asp:LinkButton ID="LinkButtonSaveCategory" runat="server" CssClass="link-button"
            Text="Create" OnClick="LinkButtonSaveCategory_Click" />
        <asp:LinkButton ID="LinkButtonCancel" runat="server" CssClass="link-button"
            Text="Cancel" OnClick="LinkButtonCancel_Click" />
    </asp:Panel>
    <asp:Panel ID="PanelDeleteCategory" runat="server" Visible="false" CssClass="panel">
        <h2>Confirm Category Deletion?</h2>
        <label>
            Category: 
            <asp:TextBox ID="TextBoxDeleteCategoryName" runat="server" Enabled="false" />
        </label>
        <asp:HiddenField ID="HiddenFieldDeleteCategoryId" runat="server" />
        <asp:LinkButton ID="LinkButtonDoDelete" runat="server" CssClass="link-button"
            Text="Yes" OnClick="LinkButtonDoDelete_Click" />
        <asp:LinkButton ID="LinkButtonCancelDelete" runat="server" CssClass="link-button"
            Text="No" OnClick="LinkButtonCancelDelete_Click" />
    </asp:Panel>
    <asp:Panel ID="PanelEditCategory" runat="server" Visible="false" CssClass="panel">
        <h2>Edit Category</h2>
        <label>
            Category: 
            <asp:TextBox ID="TextBoxEditCategoryName" runat="server" placeholder="Enter category name..." />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEditCategoryName" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Category is required!" ControlToValidate="TextBoxEditCategoryName"></asp:RequiredFieldValidator>
        </label>
        <asp:HiddenField ID="HiddenFieldEditCategoryId" runat="server" />
        <asp:LinkButton ID="LinkButtonEditSave" runat="server" CssClass="link-button"
            Text="Save" OnClick="LinkButtonEditSave_Click" />
        <asp:LinkButton ID="LinkButtonCancelEdit" runat="server" CssClass="link-button"
            Text="Cancel" OnClick="LinkButtonCancelEdit_Click" />
    </asp:Panel>
    <asp:Panel runat="server" CssClass="back-link">
        <asp:HyperLink ID="HyperLinkBack" runat="server" NavigateUrl="~">Back to books</asp:HyperLink>
    </asp:Panel>
</asp:Content>
