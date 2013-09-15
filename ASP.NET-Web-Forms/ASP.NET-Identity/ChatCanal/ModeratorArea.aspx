<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModeratorArea.aspx.cs" Inherits="WebFormsTemplate.ModeratorArea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <h1><%: Title %></h1>
        <p class="lead">Go chat</p>
    </header>
    <div>
        <asp:ListView ID="ListMessages" runat="server"
            SelectMethod="ListMessages_Get"
            UpdateMethod="ListMessages_UpdateItem"
             ItemType="ChatCanal.Data.Message"
            DataKeyNames="Id">
            <LayoutTemplate>
                <div>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                </div>

            </LayoutTemplate>
            <ItemTemplate>
                <div>
                    <p><span><%#: Item.AspNetUser.FirstName + " " + Item.AspNetUser.LastName %></span> sad: </p>
                    <p><%#: Item.Name %></p>
                    <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" />
                </div>
            </ItemTemplate>
            <EditItemTemplate>
                <div>
                    <asp:TextBox ID="TextEdit" runat="server" Text='<%#: BindItem.Name %>'></asp:TextBox>
                    <br />
                    <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                </div>

            </EditItemTemplate>
        </asp:ListView>

        <div>
            <asp:Label Text="Add new Message" runat="server" AssociatedControlID="usersMessageText" />
            <asp:TextBox runat="server" ID="usersMessageText" Columns="20" Rows="10"></asp:TextBox>

            <asp:Button ID="makePostBtn" runat="server" OnClick="makePostBtn_Click" Text="Post" />
        </div>
    </div>
</asp:Content>
