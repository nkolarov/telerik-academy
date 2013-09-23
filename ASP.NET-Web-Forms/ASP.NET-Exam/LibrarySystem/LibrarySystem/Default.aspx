<%@ Page Title="Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibrarySystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Books</h1>
    <asp:Panel ID="PanelSearch" runat="server" CssClass="search-button">
        <asp:TextBox ID="TextBoxSearchQuery" runat="server" CssClass="span3 search-query" placeholder="Search by book title / author ..." />
        <asp:LinkButton ID="ButtonSearch" Text="Search" CssClass="btn" runat="server" OnClick="ButtonSearch_Click"  />
    </asp:Panel>
    <asp:ListView ID="ListViewCategories" runat="server" ItemType="LibrarySystem.Models.Category">
        <ItemTemplate>
            <h2><%#: Item.Title %></h2>
            <ul>
                <asp:Repeater runat="server" ItemType="LibrarySystem.Models.Book" DataSource="<%# Item.Books %>">
                    <ItemTemplate>
                        <li><a href="BookDetails?id=<%#: Item.Id %>"><%#: Item.Title + " by " + Item.Author %></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
