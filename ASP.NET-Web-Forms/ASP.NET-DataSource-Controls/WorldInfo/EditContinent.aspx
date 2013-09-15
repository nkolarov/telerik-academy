<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditContinent.aspx.cs" Inherits="WorldInfo.EditContinent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Continent</title>
</head>
<body>
    <form id="formEditContinent" runat="server">
        <h3>Edit Continent</h3>
        <asp:Label ID="LabelContinent" Text="Name" runat="server" AssociatedControlID="TextBoxContinentName" />
        <asp:TextBox ID="TextBoxContinentName" runat="server" />
        <asp:RequiredFieldValidator
            ID="RequiredFieldValidatorContinentName"
            runat="server"
            ErrorMessage="Continent Name is Required!"
            ControlToValidate="TextBoxContinentName" />
        <asp:CustomValidator
            ID="CustomValidatorContinentName"
            runat="server"
            ErrorMessage="The Name is too long! Max 50 symbols allowed!"
            ControlToValidate="TextBoxContinentName"
            OnServerValidate="CustomValidatorContinentName_ServerValidate" />
        <br />
        <asp:LinkButton ID="LinkButtonSaveQuestion" runat="server"
            Text="Save" OnClick="LinkButtonSaveQuestion_Click" />
        <br />
        <a href="ManageContinents.aspx">Cancel</a>
        <asp:TextBox id="TextBoxErrorMessage" runat="server" Visible="false"/>
    </form>
</body>
</html>
