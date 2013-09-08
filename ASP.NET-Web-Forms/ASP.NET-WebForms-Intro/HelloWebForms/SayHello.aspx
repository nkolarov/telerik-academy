<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SayHello.aspx.cs" Inherits="HelloWebForms.SayHello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LabelName" runat="server" AssociatedControlID="TextBoxName" Text="Enter Your Name:"></asp:Label>
        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
    
    </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Say Hello!" />
        <p>
            <asp:TextBox ID="TextBoxResult" runat="server" Enabled="False"></asp:TextBox>
        </p>
    </form>
</body>
</html>
