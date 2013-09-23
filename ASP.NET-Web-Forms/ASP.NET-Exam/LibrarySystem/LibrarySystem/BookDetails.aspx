<%@ Page Title="Book Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="LibrarySystem.BookDetails" %>

<asp:Content ID="ContentBookDetails" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Book Details</h1>
    <asp:FormView ID="FormViewBooks" runat="server" ItemType="LibrarySystem.Models.Book">
        <ItemTemplate>
            <header>
                <p class="book-title"><%#: Item.Title %></p>
                <p class="book-author"><%#: "by" + Item.Author %></p>
                <p class="book-isbn"><%#: string.IsNullOrEmpty(Item.ISBN) ? "ISBN: (none)" : "ISBN " + Item.ISBN %></p>
                <p class="book-isbn">Web site: <a href="<%#: Item.WebSite %>"><%#: string.IsNullOrEmpty(Item.WebSite) ? " (none) " : Item.WebSite %></a></p>
            </header>
            <div class="row-fluid">
                <asp:Panel runat="server" CssClass="span12 book-description">

                    <p><%#: Item.Description %></p>
                </asp:Panel>
            </div>
        </ItemTemplate>
    </asp:FormView>
    <asp:Panel runat="server" CssClass="back-link">
        <asp:HyperLink ID="HyperLinkBack" runat="server" NavigateUrl="~">Back to books</asp:HyperLink>
    </asp:Panel>
</asp:Content>
