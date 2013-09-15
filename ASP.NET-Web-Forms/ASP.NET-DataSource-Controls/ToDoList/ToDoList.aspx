<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDoList.aspx.cs" Inherits="ToDoList.ToDoList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ToDoList</title>
</head>
<body>
    <form id="formToDoList" runat="server">
        <asp:Label ID="LabelContinents" runat="server" Text="Categories:"></asp:Label>
        <br />
        <asp:EntityDataSource
            ID="EntityDataSourceCategories"
            runat="server"
            ConnectionString="name=ToDoListEntities"
            DefaultContainerName="ToDoListEntities"
            EnableDelete="True"
            EnableInsert="True"
            EnableUpdate="True"
            EntitySetName="Categories" />
        <asp:ListBox
            ID="ListBoxContinents"
            runat="server"
            DataSourceID="EntityDataSourceCategories"
            DataTextField="Name"
            DataValueField="Id"
            AutoPostBack="true" />
        <br />
        <asp:LinkButton Text="Manage Categories" runat="server" PostBackUrl="~/ManageCategories.aspx" />
        <br />
        <asp:Label ID="LabelToDos" runat="server" Text="Todos:"></asp:Label>
        <asp:EntityDataSource
            ID="EntityDataSourceToDos"
            runat="server"
            ConnectionString="name=ToDoListEntities"
            DefaultContainerName="ToDoListEntities"
            EnableFlattening="False"
            EntitySetName="ToDos"
            Include="Category"
            Where="it.Category.Id=@CatId">
            <WhereParameters>
                <asp:ControlParameter Name="CatId" Type="Int32"
                    ControlID="ListBoxContinents" />
            </WhereParameters>
        </asp:EntityDataSource>
        <br />
        <asp:GridView
            ID="GridViewCategories"
            runat="server"
            AllowPaging="True"
            PageSize="3"
            AllowSorting="True"
            DataSourceID="EntityDataSourceToDos"
            AutoGenerateColumns="False"
            DataKeyNames="Id">
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Body" HeaderText="Body" SortExpression="Body" />
                <asp:BoundField DataField="DateModified" HeaderText="DateModified" SortExpression="DateModified" />
                <asp:BoundField DataField="Category.Name" HeaderText="Category" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:LinkButton Text="Manage ToDos" runat="server" PostBackUrl="~/ManageToDos.aspx" />
    </form>
</body>
</html>
