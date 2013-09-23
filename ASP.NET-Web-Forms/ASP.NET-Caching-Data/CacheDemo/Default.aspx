<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CacheDemo._Default" %>

<%@ Register Src="~/CacheInfo.ascx" TagPrefix="uc1" TagName="CacheInfo" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CacheInfo runat="server" ID="CacheInfo" />
</asp:Content>
