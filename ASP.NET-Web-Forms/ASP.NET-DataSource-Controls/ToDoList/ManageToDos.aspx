<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageToDos.aspx.cs" Inherits="ToDoList.ManageToDos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formManageToDos" runat="server">
        <h3>Manage ToDos</h3>
        <asp:EntityDataSource
            ID="EntityDataSourceToDos"
            runat="server"
            ConnectionString="name=ToDoListEntities"
            DefaultContainerName="ToDoListEntities"
            EnableDelete="True"
            Include="Category"
            AutoPage="true"
            EnableFlattening="False"
            EntitySetName="ToDos">
        </asp:EntityDataSource>
        <asp:GridView
            ID="GridViewToDos"
            runat="server"
            AllowPaging="True"
            PageSize="3"
            AllowSorting="True"
            DataKeyNames="Id"
            DataSourceID="EntityDataSourceToDos"
            ItemType="ToDoList.ToDo"
            AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Body" HeaderText="Body" SortExpression="Body" />
                <asp:BoundField DataField="DateModified" HeaderText="DateModified" SortExpression="DateModified" />
                <asp:BoundField DataField="Category.Name" HeaderText="Category" />
                <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="Id"
                    DataNavigateUrlFormatString="EditToDo.aspx?toDoId={0}" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonDeleteToDo" runat="server"
                            CommandName="Delete"
                            CommandArgument="<%# Item.Id %>"
                            OnClientClick="return confirm('Do you want to cancel ?');"
                            OnCommand="LinkButtonDeleteToDo_Command"
                            Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:LinkButton ID="LinkButtonCreateNewToDo" runat="server"
            Text="Create New ToDo"
            OnClick="LinkButtonCreateNewToDo_Click" />
        <section id="sectionCreateToDo" runat="server" visible="false">
            <h3>Fill new toDo info:</h3>
            <asp:EntityDataSource ID="EntityDataSourceCategories" runat="server" ConnectionString="name=ToDoListEntities" DefaultContainerName="ToDoListEntities" EnableFlattening="False" EntitySetName="Categories"></asp:EntityDataSource>
            <asp:Label ID="LabelCategories" Text="Category" runat="server" AssociatedControlID="ListBoxCategories" />
            <asp:DropDownList ID="ListBoxCategories" runat="server" AppendDataBoundItems="True" DataSourceID="EntityDataSourceCategories" DataTextField="Name" DataValueField="Id">
                <asp:ListItem Text="--Select--" Value="-1" />
            </asp:DropDownList>
            <asp:CustomValidator
                ID="CustomValidatorCategory"
                runat="server"
                ErrorMessage="You must select a category!"
                ControlToValidate="ListBoxCategories"
                OnServerValidate="CustomValidatorCategory_ServerValidate" />
            <br />
            <asp:Label ID="LabelToDoTitle" Text="Title" runat="server" AssociatedControlID="TextBoxToDoTitle" />
            <asp:TextBox ID="TextBoxToDoTitle" runat="server" />
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidatorToDoTitle"
                runat="server"
                ErrorMessage="ToDo Title is Required!"
                ControlToValidate="TextBoxToDoTitle" />
            <asp:CustomValidator
                ID="CustomValidatorToDoTitle"
                runat="server"
                ErrorMessage="The Title is too long! Max 50 symbols allowed!"
                ControlToValidate="TextBoxToDoTitle"
                OnServerValidate="CustomValidatorToDoName_ServerValidate" />
            <br />
            <asp:Label ID="LabelBody" Text="Body" runat="server" AssociatedControlID="TextBoxBody" />
            <asp:TextBox ID="TextBoxBody" runat="server" TextMode="MultiLine"/>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidatorBody"
                runat="server"
                ErrorMessage="ToDo Name is Required!"
                ControlToValidate="TextBoxBody" />
            <asp:CustomValidator
                ID="CustomValidatorBody"
                runat="server"
                ErrorMessage="The Body is too long! Max 255 symbols allowed!"
                ControlToValidate="TextBoxBody"
                OnServerValidate="CustomValidatorToDoBody_ServerValidate" />
            <br />
            <asp:LinkButton ID="LinkButtonSaveToDo" runat="server"
                Text="Save" OnClick="LinkButtonSaveToDo_Click" />
            <br />
            <a href="ManageToDos.aspx">Cancel</a>
            <asp:Literal ID="LiteralErrorMessage" runat="server" Visible="false" />
        </section>
    </form>
    <br />
    <a href="ToDoList.aspx">Back to ToDo Lists</a>
</body>
</html>
