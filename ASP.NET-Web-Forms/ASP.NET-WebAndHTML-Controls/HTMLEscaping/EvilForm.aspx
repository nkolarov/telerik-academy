<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EvilForm.aspx.cs" Inherits="HTMLEscaping.EvilForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBoxInput" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <br />
        <br />
        <asp:TextBox ID="TextBoxOutput" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />
        <asp:Label ID="LabelOutput" runat="server" Text="Label"></asp:Label>
    
    </div>
    </form>
</body>
</html>
