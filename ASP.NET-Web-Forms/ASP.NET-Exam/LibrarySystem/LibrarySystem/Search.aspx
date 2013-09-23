<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="LibrarySystem.Search" %>

<asp:Content ID="ContentSearchDetails" ContentPlaceHolderID="MainContent" runat="server">

    <h1 id="SearchHeader" runat="server">My content will be loaded dynamically!</h1>
    <asp:ListView ID="ListViewSearch" runat="server" ItemType="LibrarySystem.Models.Book">
        <ItemTemplate>
            <li>
                <a href="BookDetails?id=<%#: Item.Id %>"><%#: Item.Title + " by " + Item.Author %></a>
                (Category: <%#: Item.Category.Title %>)
                <span></li>
        </ItemTemplate>
    </asp:ListView>
    <asp:Panel runat="server" CssClass="back-link">
        <asp:HyperLink ID="HyperLinkBack" runat="server" NavigateUrl="~">Back to books</asp:HyperLink>
    </asp:Panel>
</asp:Content>
