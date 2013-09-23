<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Threads.aspx.cs"
    Inherits="BgTatkoForum.Threads" %>

<asp:Content ID="BodyContent" runat="server"
    ContentPlaceHolderID="MainContent">
    <asp:GridView ID="GridThreads" runat="server"
        ItemType="BgTatkoForum.Models.Thread"
        AutoGenerateColumns="false" AllowPaging="true"
        PageSize="3" SelectMethod="GridThreads_GetData"
        BorderStyle="None" AllowSorting="true">
        <Columns>
            <asp:TemplateField>
                <HeaderStyle BorderStyle="None" />
                <HeaderTemplate>
                    <asp:LinkButton CssClass="btn btn-info"
                        Text="By date" runat="server"
                        OnCommand="SortByDate_Command" />
                    <asp:LinkButton CssClass="btn btn-info"
                        Text="Most votes" runat="server"
                        OnCommand="SortByVotes_Command" />
                    <asp:LinkButton CssClass="btn btn-info"
                        Text="Most posts" runat="server"
                        OnCommand="SortByPosts_Command" />
                    <br />
                    <h2><%#: ViewState["query"] %></h2>
                </HeaderTemplate>
                <ItemStyle BorderStyle="None" />
                <ItemTemplate>
                    <div>
                        <div class="thread-votes">
                            <span class="vote-action">
                                <asp:LinkButton runat="server"
                                    CommandArgument="<%# Item.ThreadId.ToString() + ',' + Context.User.Identity.GetUserId() %>"
                                    OnCommand="VoteUp_Command"
                                    CssClass="vote vote-up" />
                                <asp:LinkButton runat="server"
                                    CommandArgument="<%# Item.ThreadId.ToString() + ',' + Context.User.Identity.GetUserId() %>"
                                    OnCommand="VoteDown_Command"
                                    CssClass="vote vote-down" />
                            </span>
                            <div class="votes-results">
                                <strong class="value">
                                    <%#:Item.ThreadVotes.Sum(v => v.Value)%>
                                </strong>
                                <div>votes</div>
                            </div>
                        </div>
                        <div class="thread-posts">
                            <div class="posts-num">
                                <strong class="posts-num-value">
                                    <%#: Item.Posts.Count %>
                                </strong>
                                <div>
                                    posts
                                </div>
                            </div>
                        </div>
                        <div class="thread-info">
                            <asp:LinkButton ID="LinkButtonThread"
                                runat="server"
                                Text="<%#: Item.Title %>"
                                CommandArgument="<%#: Item.ThreadId %>"
                                OnCommand="LinkButtonThread_Command" />
                            <h4></h4>
                            <p>
                                in
                                <asp:LinkButton runat="server"
                                    Text="<%#: Item.Category.Name %>"
                                    CommandArgument="<%# Item.CategoryId %>"
                                    OnCommand="SelectCategory_Command" />
                                on the <%#: Item.DateCreated %>
                            </p>
                            <asp:Repeater ID="RepeaterTags"
                                runat="server"
                                DataSource="<%# Item.Tags %>"
                                ItemType="BgTatkoForum.Models.Tag">
                                <ItemTemplate>
                                    <span class="tags">
                                        <asp:LinkButton runat="server"
                                            Text="<%#: Item.Name %>"
                                            CssClass="badge badge-info"
                                            CommandArgument="<%# Item.TagId %>"
                                            OnCommand="SelectTag_Command" />
                                    </span>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterStyle BorderStyle="None" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
