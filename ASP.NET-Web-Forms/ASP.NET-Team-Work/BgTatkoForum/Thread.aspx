<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Thread.aspx.cs" Inherits="BgTatkoForum.Thread" %>

<asp:Content ID="ContentCurrentThread" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="FormViewThread" runat="server" ItemType="BgTatkoForum.Models.Thread">
        <ItemTemplate>
            <div class="thread-votes">
                <span class="vote-action">
                    <asp:LinkButton runat="server"
                        CommandArgument="<%# Item.ThreadId.ToString() + ',' + Context.User.Identity.GetUserId() %>"
                        OnCommand="VoteUp_Command"
                        CssClass="vote vote-up" />
                    <asp:LinkButton runat="server"
                        CommandArgument="<%# Item.ThreadId.ToString() + ',' + Context.User.Identity.GetUserId() %>"
                        OnCommand="VoteDown_Command"
                        CssClass="vote vote-down" /></span>
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
            <br />
            <div class="thread-info">
                <h2 id="ThreadTitle">Title: <%#:Item.Title %></h2>
            </div>
            <div id="ThreadContent" class="lead"><%#:Item.Content %></div>
            <br />
        </ItemTemplate>
    </asp:FormView>

    <asp:LinkButton ID="LinkButtonCreateNewPost" runat="server"
        Text="Create New Post" CssClass="btn btn-primary btn-mini"
        OnClick="LinkButtonCreateNewPost_Click" />
    <section id="sectionCreatePost" runat="server" visible="false">
        <h3>Fill new post info:</h3>
        <asp:Label ID="LabelPostContent" Text="Content: " runat="server" AssociatedControlID="TextBoxPostContent" />
        <asp:TextBox ID="TextBoxPostContent" runat="server" TextMode="MultiLine" />
        <asp:RequiredFieldValidator
            ID="RequiredFieldValidatorContinentName"
            runat="server"
            ErrorMessage="Post Content is Required!"
            ControlToValidate="TextBoxPostContent" />
        <div class="btn-group">
            <asp:LinkButton ID="LinkButtonSavePost" runat="server"
                CommandArgument='<%# Request.Params["threadId"] %>'
                CssClass="btn btn-primary btn-mini"
                Text="Save" OnCommand="LinkButtonSavePost_Click" />
            <a class="btn btn-primary btn-mini" href="<%# Request.Url %>">Cancel</a>
        </div>
        <asp:Literal ID="LiteralErrorMessage" runat="server" Visible="false" />
    </section>

    <section id="sectionCreateCommentForPost" runat="server" visible="false">
        <h3>Fill new comment info:</h3>
        <asp:HiddenField ID="HiddenFieldSlectedPostId" runat="server" />
        <asp:Label ID="LabelCommentContent" Text="Content: " runat="server" AssociatedControlID="TextBoxCommentContent" />
        <asp:TextBox ID="TextBoxCommentContent" runat="server" TextMode="MultiLine" />
        <asp:RequiredFieldValidator
            ID="RequiredFieldValidatorCommentName"
            runat="server"
            ErrorMessage="Post Content is Required!"
            ControlToValidate="TextBoxCommentContent" />
        <br />
        <div class="btn-group">
            <asp:LinkButton ID="LinkButtonSaveComment" runat="server"
                CssClass="btn btn-primary btn-mini"
                Text="Save" OnClick="LinkButtonSaveComment_Click" />
            <a class="btn btn-primary btn-mini" href="<%# Request.Url %>">Cancel</a>
        </div>
        <asp:Literal ID="Literal1" runat="server" Visible="false" />
    </section>
    <h3>Posts</h3>
    <asp:ListView ID="FormViewPosts" runat="server" ItemType="BgTatkoForum.Models.Post" DataKeyNames="PostId">
        <ItemTemplate>
            <h4>Post:</h4>
            <div class="post">
                <p class="post-content">
                    <%#: Item.Content %>
                <p class="post-postedBy">
                    <%#: "Posted By: " + Item.User.UserName %>
            </div>
            <asp:LinkButton ID="LinkButtonCreateNewComment" runat="server"
                Text="Create New Comment" CssClass="btn btn-primary btn-mini"
                CommandArgument="<%# Item.PostId %>"
                OnCommand="LinkButtonCreateNewComment_Command" />
            <asp:Repeater ID="RepeaterPostCommetns" runat="server"
                DataSource="<%# Item.Comments %>"
                ItemType="BgTatkoForum.Models.Comment">
                <ItemTemplate>
                    <p>Comment:</p>
                    <div class="post-comment">
                        <p class="post-comment-content">
                            <%#: Item.Content %>
                        <p class="post-comment-postedBy">
                            <%#: "Posted By: " + Item.User.UserName %>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
