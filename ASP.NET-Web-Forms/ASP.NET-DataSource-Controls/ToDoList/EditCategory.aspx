<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCategory.aspx.cs" Inherits="ToDoList.EditCategory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
  <form id="formEditCategory" runat="server">
        <h3>Edit Category</h3>
        <asp:Label ID="LabelCategory" Text="Name" runat="server" AssociatedControlID="TextBoxCategoryName" />
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
            Text="Save" OnClick="LinkButtonSaveQuestion_Click" />
        <br />
        <a href="ManageCategories.aspx">Cancel</a>
        <asp:TextBox id="TextBoxErrorMessage" runat="server" Visible="false"/>
    </form>
</body>
</html>
