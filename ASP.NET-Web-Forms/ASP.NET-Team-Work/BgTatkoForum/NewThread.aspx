<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewThread.aspx.cs" Inherits="BgTatkoForum.NewThread" %>
<asp:Content ID="ContentNewThread" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Create New Thread</h1>
    <asp:Label CssClass="label" Text="Thread Title:" runat="server" AssociatedControlID="TextBoxTitle" />
    <asp:TextBox ID="TextBoxTitle" runat="server" />
    <br />
    <asp:Label CssClass="label" Text="Category:" runat="server" AssociatedControlID="DropDownListCategory" />
    <asp:DropDownList CssClass="btn dropdown-toggle" runat="server" ID="DropDownListCategory" ItemType="BgTatkoForum.Models.Category" DataValueField="CategoryId" DataTextField="Name" />
    <br />
    <asp:Label CssClass="label" Text="Content:" runat="server" AssociatedControlID="TextBoxContent" />
    <asp:TextBox ID="TextBoxContent" runat="server" TextMode="MultiLine" Rows="10" />
    <br />
    <asp:Label CssClass="label" Text="Tags:" runat="server" AssociatedControlID="TextBoxTags" />
    <asp:TextBox ID="TextBoxTags" runat="server" />
    <br />
    <asp:LinkButton ID="LinkButtonSaveThread" CssClass="btn btn-primary" Text="Save" runat="server" OnClick="LinkButtonSaveThread_Click" />
    <asp:RequiredFieldValidator
            ID="RequiredFieldValidatorThreadTitle"
            runat="server"
            ErrorMessage="Thread Title is Required!"
            ControlToValidate="TextBoxTitle" />
</asp:Content>
