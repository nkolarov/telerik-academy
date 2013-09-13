<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArbitaryXML.aspx.cs" Inherits="XMLTreeView.ArbitaryXML" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Arbitary XML</title>
</head>
<body>
    <form id="treeForm" runat="server">
        <asp:Label ID="LiteralLabel" Text="Selected Leaf info:" AssociatedControlID="LeafInfo" runat="server" />
        <asp:Literal ID="LeafInfo" runat="server" />
        <asp:XmlDataSource ID="XmlDataSourceArbitary" runat="server" DataFile="~/sample.xml"></asp:XmlDataSource>
        <asp:TreeView ID="TreeViewXML" runat="server" EnableClientScript="true" ShowExpandCollapse="false" DataSourceID="XmlDataSourceArbitary" ImageSet="Arrows" OnSelectedNodeChanged="TreeViewXML_SelectedNodeChanged" >
        </asp:TreeView>
    </form>
</body>
</html>
