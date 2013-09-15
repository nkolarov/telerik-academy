<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCategories.aspx.cs" Inherits="ToDoList.ManageCategories" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage CAtegories</title>
</head>
<body>
  <form id="formManageCategories" runat="server">
        <h3>Manage Categories</h3>
        <asp:EntityDataSource
            ID="EntityDataSourceCategories"
            runat="server"
            ConnectionString="name=ToDoListEntities"
            DefaultContainerName="ToDoListEntities"
            EnableDelete="True"
            EnableFlattening="False"
            EntitySetName="Categories">
        </asp:EntityDataSource>
        <asp:GridView
            ID="GridViewCategories"
            runat="server"
            AllowSorting="True"
            DataKeyNames="Id"
            DataSourceID="EntityDataSourceCategories"
            ItemType="ToDoList.Category"
            AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="Id"
                    DataNavigateUrlFormatString="EditCategory.aspx?CategoryId={0}" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonDeleteCategory" runat="server"
                            CommandName="Delete"
                            CommandArgument="<%# Item.Id %>"
                            OnClientClick="return confirm('Do you want to cancel ?');"
                            OnCommand="LinkButtonDeleteCategory_Command"
                            Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:LinkButton ID="LinkButtonCreateNewCategory" runat="server"
            Text="Create New Category"
            OnClick="LinkButtonCreateNewCategory_Click" />
        <section id="sectionCreateCategory" runat="server" visible="false">
            <h3>Fill new Category info:</h3>
            <asp:Label ID="LabelCategoryName" Text="Name" runat="server" AssociatedControlID="TextBoxCategoryName"/>
            <asp:TextBox ID="TextBoxCategoryName" runat="server" />
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidatorCategoryName"
                runat="server"
                ErrorMessage="Category Name is Required!"
                ControlToValidate="TextBoxCategoryName" />
            <asp:CustomValidator
                ID="CustomValidatorCategoryName"
                runat="server"
                ErrorMessage="The Name is too long! Max 50 symbols allowed!"
                ControlToValidate="TextBoxCategoryName"
                OnServerValidate="CustomValidatorCategoryName_ServerValidate" />
            <br />
            <asp:LinkButton ID="LinkButtonSaveQuestion" runat="server"
                Text="Save" OnClick="LinkButtonSaveCategory_Click" />
            <br />
            <a href="ManageCategories.aspx">Cancel</a>
            <asp:Literal Id="LiteralErrorMessage" runat="server" Visible="false"/>
        </section>
    </form>
    <br />
    <a href="ToDoList.aspx">Back to ToDo Lists</a>
</body>
</html>
