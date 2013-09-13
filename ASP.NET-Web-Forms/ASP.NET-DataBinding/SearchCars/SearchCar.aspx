<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchCar.aspx.cs" Inherits="SearchCars.SearchCar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="searchForm" runat="server">
        <asp:Label ID="LabelProducer" runat="server" Text="Producer:" AssociatedControlID="DropDownListProducer"></asp:Label>
        <asp:DropDownList ID="DropDownListProducer" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListProducer_SelectedIndexChanged" AppendDataBoundItems="True">
             <asp:ListItem Text="--Select--" Value ="default"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="LabelModel" runat="server" Text="Model" AssociatedControlID="DropDownListModel"></asp:Label>
        <asp:DropDownList ID="DropDownListModel" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="LabelExtras" runat="server" AssociatedControlID="CheckBoxListExtras" Text="Extras"></asp:Label>
        <asp:CheckBoxList ID="CheckBoxListExtras" runat="server"></asp:CheckBoxList>
        <asp:Label ID="LabelEngines" runat="server" AssociatedControlID="RadioButtonListEngines" Text="Engines"></asp:Label>
        <asp:RadioButtonList ID="RadioButtonListEngines" RepeatDirection="Horizontal" runat="server">
        </asp:RadioButtonList>
        <asp:Button ID="ButtonSearch" runat="server" Text="Search" OnClick="ButtonSearch_Click" />
        <br />
        <asp:Literal ID="LiteralSearchData" runat="server"></asp:Literal>
    </form>
</body>
</html>
