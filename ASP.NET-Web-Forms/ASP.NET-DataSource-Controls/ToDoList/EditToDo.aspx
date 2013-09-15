<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditToDo.aspx.cs" Inherits="ToDoList.EditToDo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit ToDo</title>
</head>
<body>
    <form id="formManageToDos" runat="server">
        <section id="sectionCreateToDo" runat="server">
            <h3>Edit toDo info:</h3>
             <asp:Label ID="LabelCategories" Text="Category" runat="server" AssociatedControlID="ListBoxCategories" />
            <asp:DropDownList ID="ListBoxCategories" runat="server" AppendDataBoundItems="True" DataTextField="Name" DataValueField="Id">
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
