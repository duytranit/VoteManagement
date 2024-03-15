<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="VoteManagement.Views.Employee.Vote.Index" %>
<%@ Register TagPrefix="Partial" TagName="EMPRGVote" Src="~/Partials/Vote/EMPRGVote.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <Partial:EMPRGVote ID="partialEMPRGVote" runat="server" />
</asp:Content>
