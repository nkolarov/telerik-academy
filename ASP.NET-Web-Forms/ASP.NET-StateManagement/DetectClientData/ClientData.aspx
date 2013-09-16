<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientData.aspx.cs" Inherits="DetectClientData.ClientData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Client Data</title>
</head>
<body>
    <form id="formClientData" runat="server">
        <asp:Literal Id="ClientBrowserType" Text="ClientBrowserType" runat="server" />
        <br />
        <asp:Literal Id="ClientIpAddress" Text="ClientIpAddress" runat="server" />
    </form>
</body>
</html>
