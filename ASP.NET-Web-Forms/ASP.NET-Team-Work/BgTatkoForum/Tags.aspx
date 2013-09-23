<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tags.aspx.cs" Inherits="BgTatkoForum.Tags" %>

<asp:Content ID="ContentTags" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanelComments" runat="server">
        <ContentTemplate>
            <asp:GridView CssClass="table table-hover" runat="server" ID="GridViewTags" ItemType="BgTatkoForum.Models.Tag"
                AutoGenerateColumns="false" PageSize="5" AllowPaging="true"
                SelectMethod="GridViewTags_GetData">
                <Columns>
                    <asp:TemplateField HeaderText="Most popular tags">
                        <ItemTemplate>
                            <div>
                                <asp:LinkButton CssClass="btn btn-info" ID="LinkButtonTag" Text='<%#: Item.Name %>' runat="server"
                                    OnCommand="LinkButtonTag_Command"
                                    CommandArgument="<%# Item.TagId %>" />
                                x <%# Item.Threads.Count %>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Timer ID="TimerComments" runat="server" Interval="5000" OnTick="TimerComments_Tick"></asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
