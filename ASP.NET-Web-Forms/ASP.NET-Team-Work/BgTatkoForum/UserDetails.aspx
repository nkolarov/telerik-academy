<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="UserDetails.aspx.cs"
    Inherits="BgTatkoForum.UserDetails" %>

<asp:Content ID="ContentUserDetails" ContentPlaceHolderID="MainContent" runat="server">

    <asp:FormView ID="FormViewUserDetails" runat="server"
        AllowPaging="False" DataKeyNames="FullName, DisplayName"
        ItemType="BgTatkoForum.Models.UserDisplayModel">
        <ItemTemplate>
            <h2>User: <%#: Item.DisplayName %></h2>
            <hr />
            <div>
                <table class="mainUserInfo">
                    <tr>
                        <td class="leftTd"></td>
                        <td>
                            <a href="UserDetails.aspx?userId=<%# Item.Id %>" target="_self">
                                <asp:Image OnPreRender="Avatar_PreRender" runat="server" />
                            </a>

                        </td>
                    </tr>
                    <tr>
                        <td class="leftTd">Member for:</td>
                        <td>
                            <%#: Item.Member %> days in the forum
                        </td>
                    </tr>
                    <tr>
                        <td class="leftTd">Full name: :</td>
                        <td><%#: Item.FullName %></td>
                    </tr>
                    <tr>
                       <td class="leftTd">Website:</td>
                        <td><%#: Item.UserDetails.WebSite %></td>
                    </tr>
                    <tr>
                        <td class="leftTd">About user:</td>
                        <td><%#: Item.UserDetails.About %></td>
                    </tr>
                    <tr>
                </table>
            </div>

            <h3>Activity by <%#: Item.DisplayName %></h3>
            <hr />
            <div>
                <table class="forumUserInfo">
                    <tr>
                        <td>Score:</td>
                        <td><%#: Item.Score %></td>
                    </tr>
                    <tr>
                        <td>Threads:</td>
                        <td><%#: Item.User.Threads.Count %></td>
                    </tr>
                    <tr>
                        <td>Posts:</td>
                        <td><%#: Item.User.Posts.Count %></td>
                    </tr>
                    <tr>
                        <td>Comments:</td>
                        <td><%#: Item.User.Comments.Count %></td>
                    </tr>
                    <tr>
                </table>
            </div>
            <hr />
        </ItemTemplate>
    </asp:FormView>

    <asp:ListView ID="ListViewPosts" runat="server"
        ItemType="BgTatkoForum.Models.Post">
        <ItemTemplate>
            <p>
                <span>Thread: <asp:LinkButton Text="<%#: Item.Thread.Title %>" runat="server"
                    CommandArgument="<%#: Item.Thread.ThreadId %>"
                    OnCommand="Thread_Command" /></span>
                <span>Posted in category: <asp:LinkButton Text="<%#: Item.Thread.Category.Name %>" runat="server"
                    CommandArgument="<%#: Item.Thread.CategoryId %>"
                    OnCommand="Category_Command" /></span>
            </p>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
