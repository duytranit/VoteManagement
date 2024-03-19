<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="VoteManagement.Views.Admin.Vote.Index" %>
<%@ Register TagPrefix="Partial" TagName="RGVote" Src="~/Partials/Vote/RGVote.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ContentPlaceHolderID="pageTitle" runat="server">
    QUẢN LÝ BỎ PHIẾU
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <Partial:RGVote runat="server" />
</asp:Content>
