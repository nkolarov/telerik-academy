<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HelloCookie.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formLogin" runat="server">
        <fieldset>
            <legend>Login</legend>
            <asp:Label Text="UserName:" runat="server" AssociatedControlID="TextUserName"/>
            <asp:TextBox runat="server" id="TextUserName"/>
            <br />
            <asp:Button id="ButtonLogMeIn" Text="Login" runat="server" OnClick="ButtonLogMeIn_Click" />
        </fieldset>            
    </form>
</body>
</html>
