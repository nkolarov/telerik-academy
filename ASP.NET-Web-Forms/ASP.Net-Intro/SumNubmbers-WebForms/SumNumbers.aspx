<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SumNumbers.aspx.cs" Inherits="SumNubmbers_WebForms.SumNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Label ID="LabelFirstNumber" runat="server" AssociatedControlID="TextBoxFirstNumber" Text="FirstNumner"></asp:Label>
        <asp:TextBox ID="TextBoxFirstNumber" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="LabelSecondNumber" runat="server" AssociatedControlID="TextBoxSecondNumber" Text="SecondNumber"></asp:Label>
        <asp:TextBox ID="TextBoxSecondNumber" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Calculate" />
        <br />
        Sum Result:<asp:TextBox ID="TextBoxSumResult" runat="server" Enabled="False"></asp:TextBox>
    </form>
</body>
</html>
