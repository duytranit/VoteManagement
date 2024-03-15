<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CUD.aspx.cs" Inherits="VoteManagement.Views.Admin.Vote.CUD" %>
<%@ Register TagPrefix="Partial" TagName="RGQuestion" Src="~/Partials/Question/RGQuestion.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTitle" runat="server">
    QUẢN LÝ BẦU CỬ
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    Nội dung bầu cử:
    <asp:Label ID="lblName" runat="server" Font-Bold="true"/>
    <Partial:RGQuestion ID="RGQuestion" runat="server" />
</asp:Content>
