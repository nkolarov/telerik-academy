<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserArea.aspx.cs" Inherits="WebFormsTemplate.UserArea" %>

<asp:Content ID="ContentUserArea" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <h1><%: Title %></h1>
        <p class="lead">Go chat</p>
    </header>
    <div>
        <asp:ListView ID="ListPosts" runat="server" SelectMethod="ListMessages" ItemType="ChatCanal.Data.Message">
            <LayoutTemplate>
                <div>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                </div>

            </LayoutTemplate>
            <ItemTemplate>
                <div>
                    <p>Author: <span><%#: Item.AspNetUser.FirstName + Item.AspNetUser.LastName %></span></p>
                    <p><%#: Item.Name %></p>
                </div>
            </ItemTemplate>
        </asp:ListView>

        <div>
            <asp:Label Text="Add new Message" runat="server" AssociatedControlID="usersMessageText"        />
                   <asp:TextBox runat="server" ID="usersMessageText" Columns="20" Rows="10"></asp:TextBox>

            <asp:Button ID="makePostBtn" runat="server" OnClick="makePostBtn_Click" Text="Post" />
        </div>
    </div>
</asp:Content>
