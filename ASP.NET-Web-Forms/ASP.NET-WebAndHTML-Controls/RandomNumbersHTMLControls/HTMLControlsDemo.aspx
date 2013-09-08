<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HTMLControlsDemo.aspx.cs" Inherits="RandomNumbersHTMLControls.HTMLControlsDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <label for="TextFirstNumber">Min:</label>
        <input id="TextFirstNumber" type="text" runat="server"/><br />
        <label for="TextSecondNumber">Max:</label>
        <input id="TextSecondNumber" type="text" runat="server"/><br />
        <input id="ButtonGenerate" runat="server" onserverclick="onButtonGenerateClick" type="button" value="Generate" /><br />
        <input id="TextResult" readonly="true" type="text" runat="server"/></div>
    </form>
</body>
</html>
