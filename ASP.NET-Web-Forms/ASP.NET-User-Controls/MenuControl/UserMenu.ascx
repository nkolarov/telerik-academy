<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserMenu.ascx.cs" Inherits="MenuControl.UserMenu" %>

<ul class="userMenu">

    <asp:DataList ID="DataListUserMenu" runat="server">
        <ItemTemplate>
            <a class="userMenuItem" href='<%# Eval("Url") %>' style='color: <%# Eval("FontColor")  %>'><%# Eval("Name") %></a>
        </ItemTemplate>
    </asp:DataList>
</ul>
