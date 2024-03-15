<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="CUD.aspx.cs" Inherits="VoteManagement.Views.Employee.Question.CUD" %>
<%@ Register TagPrefix="Partial" TagName="FormAccountAnswer" Src="~/Partials/AccountAnswer/Form.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <Partial:FormAccountAnswer ID="formAccountAnswer" runat="server" />
</asp:Content>
