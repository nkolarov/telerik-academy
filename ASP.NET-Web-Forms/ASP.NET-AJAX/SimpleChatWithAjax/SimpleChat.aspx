<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SimpleChat.aspx.cs" Inherits="SimpleChatWithAjax.SimpleChat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Simple Chat</title>
</head>
<body>
    <form id="formSimpleChat" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
        <asp:Panel runat="server">
            <asp:Label ID="LabelUserName" runat="server" Text="UserName" AssociatedControlID="TextBoxUserName"></asp:Label>
            <asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox>
            <asp:Label ID="LabelMessage" runat="server" Text="Message" AssociatedControlID="TextBoxMessage"></asp:Label>
            <asp:TextBox ID="TextBoxMessage" runat="server"></asp:TextBox>
            <asp:LinkButton Id="LinkButtonSendMessage" Text="Send Message" runat="server" OnClick="LinkButtonSendMessage_Click"/>
        </asp:Panel>
        <asp:ListView runat="server" ID="ListViewSimpleChat" ItemType="SimpleChatWithAjax.Models.Message" DataKeyNames="Id">
            <LayoutTemplate>
                <asp:UpdatePanel ID="UpdatePanelSimpleChat" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger EventName="Tick" ControlID="TimerChatListReload" />
                    </Triggers>
                    <ContentTemplate>
                        <div id="itemPlaceHolder" runat="server"></div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </LayoutTemplate>
            <ItemTemplate>
                <div>
                    <%#: Item.UserName %> said: <%#: Item.Text %>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <asp:Timer ID="TimerChatListReload" runat="server" Interval="2000" />
    </form>
</body>
</html>
