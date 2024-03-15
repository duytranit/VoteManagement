<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CUD.aspx.cs" Inherits="VoteManagement.Views.Admin.Question.CUD" %>
<%@ Register TagPrefix="Partial" TagName="RGAnswer" Src="~/Partials/Answer/RGAnswer.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="pageTitle" runat="server">
    QUẢN LÝ BẦU CỬ
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    Nội dung bầu cử:
    <asp:Label ID="lblVOTName" runat="server" Font-Bold="true"/>
    <br />
    Nội dung bình chọn:
    <asp:Label ID="lblQUEContent" runat="server" Font-Bold="true" />
    <Partial:RGAnswer ID="RGAnswer" runat="server" />
</asp:Content>
