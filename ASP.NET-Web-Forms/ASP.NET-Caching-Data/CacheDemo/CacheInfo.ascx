<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CacheInfo.ascx.cs" Inherits="CacheDemo.CacheInfo" %>
<%@ OutputCache Duration="10" VaryByParam="none" %>

<h1>Cash datetime: <%= DateTime.Now %></h1>
