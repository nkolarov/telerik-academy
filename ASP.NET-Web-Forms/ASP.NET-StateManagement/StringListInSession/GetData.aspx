<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetData.aspx.cs" Inherits="StringListInSession.GetData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formSessionData" runat="server">
        <asp:Label ID="InputTest" runat="server" Text="Enter Data:" AssociatedControlID="TextBoxData"></asp:Label>
        <asp:TextBox ID="TextBoxData" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="ButtonSave" runat="server" Text="SaveData" OnClick="ButtonSave_Click" />
        <br />
        <br />
        <asp:Literal ID="LiteralEnteredData" runat="server"></asp:Literal>
    </form>
</body>
</html>
