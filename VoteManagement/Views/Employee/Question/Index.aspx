<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="VoteManagement.Views.Employee.Question.Index" %>
<%@ Register TagPrefix="Partial" TagName="RGQuestion" Src="~/Partials/Question/RGQuestionOfAccount.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <Partial:RGQuestion ID="partialRGQuestion" runat="server" />
</asp:Content>
