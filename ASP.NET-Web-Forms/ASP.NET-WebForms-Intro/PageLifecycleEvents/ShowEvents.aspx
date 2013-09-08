<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowEvents.aspx.cs" Inherits="PageLifecycleEvents.ShowEvents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="ButtonOK" runat="server" Text="Hit me!" OnInit="ButtonOK_Init" OnLoad="ButtonOK_Load" OnClick="ButtonOK_Click"
            OnPreRender="ButtonOK_PreRender" OnUnload="ButtonOK_Unload"/>
    
    </div>
    </form>
</body>
</html>
