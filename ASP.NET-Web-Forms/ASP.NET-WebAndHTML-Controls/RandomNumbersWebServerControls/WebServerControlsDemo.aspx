<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebServerControlsDemo.aspx.cs" Inherits="RandomNumbersWebServerControls.WebServerControlsDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LabelMin" runat="server" Text="Min" AssociatedControlID="TextBoxMin"></asp:Label>
        <asp:TextBox ID="TextBoxMin" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="LabelMax" runat="server" Text="Max" AssociatedControlID="TextBoxMax"></asp:Label>
        <asp:TextBox ID="TextBoxMax" runat="server" ></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Generate" OnClick="Button1_Click" />
        <br />
        <asp:TextBox ID="TextBoxRandom" runat="server" Enabled="False"></asp:TextBox>
    
    </div>
    </form>
</body>
</html>
