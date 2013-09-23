<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditThreads.aspx.cs" Inherits="BgTatkoForum.Admin.EditThreads" %>
<asp:Content ID="ContentEditThreads" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView CssClass="table table-hover" ID="GridViewEditThreads" runat="server"
        ItemType="BgTatkoForum.Models.Thread"
        AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true"
        PageSize="5" SelectMethod="GridViewEditThreads_GetData">
        <Columns>
            <asp:BoundField HeaderText="Thread Title" DataField="Title" SortExpression="Title"/>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton CssClass="btn btn-danger" ID="LinkButtonDelete" Text="Delete" runat="server" OnCommand="LinkButtonDelete_Command" CommandArgument="<%# Item.ThreadId %>"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:FormView ID="FormViewDeleteThread" runat="server" ItemType="BgTatkoForum.Models.Thread" Visible="false">
        <ItemTemplate>
            <asp:Label CssClass="label" Text="Title:" runat="server" AssociatedControlID="TextBoxTitle" />
            <asp:TextBox ID="TextBoxTitle" runat="server" Text="<%# Item.Title %>" Enabled="false" />
            <br />
            <asp:Label CssClass="label" Text="Author:" runat="server" AssociatedControlID="TextBoxAuthor" />
            <asp:TextBox ID="TextBoxAuthor" runat="server" Text="<%# Item.User.UserName %>" Enabled="false" />
            <br />
            <div class="btn-group">
                <asp:LinkButton CssClass="btn btn-danger" ID="LinkButtonDeleteThread" Text="Delete" OnCommand="LinkButtonDeleteThread_Command" CommandArgument="<%# Item.ThreadId %>" runat="server" />
                <asp:LinkButton CssClass="btn btn-primary" ID="LinkButtonCancelDelete" Text="Cancel" OnCommand="LinkButtonCancelDelete_Command" runat="server" />
            </div>
            </ItemTemplate>
    </asp:FormView>
</asp:Content>
