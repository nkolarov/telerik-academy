<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoveViewstate.aspx.cs" Inherits="RemoveViewstate.RemoveViewstate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Viewstate</title>
    <script src="Scripts/jquery-2.0.3.js"></script>
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
            <button id="deleteViewstate">Delete ViewState</button>
    <script>
        $("#deleteViewstate").on("click", function () {
            $("#__VIEWSTATE").val("");
        });
    </script>
</body>
</html>
