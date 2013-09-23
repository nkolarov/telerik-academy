<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CacheDemo.About" %>
<%@ OutputCache Duration="3600" VaryByParam="none" %>
<%@ Register Src="~/CacheInfo.ascx" TagPrefix="uc1" TagName="CacheInfo" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <h1><%: Title %></h1>
        <p class="lead">Your app description page.</p>
    </header>

    <div class="row-fluid">
        <div class="span12">
            <h1>Current datetime: <%= DateTime.Now %></h1>
        </div>
    </div>

</asp:Content>
