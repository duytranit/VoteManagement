<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CUD.aspx.cs" Inherits="VoteManagement.Views.Admin.Question.CUD" %>
<%@ Register TagPrefix="Partial" TagName="RGAnswer" Src="~/Partials/Answer/RGAnswer.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="pageTitle" runat="server">
    QUẢN LÝ BỎ PHIẾU
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 50px; padding-top: 15px; padding-left: 10px; background-color: gainsboro;">
        <telerik:RadButton ID="btPrevious" runat="server" Text="Trở về" OnClick="btPrevious_Click">
            <Icon PrimaryIconCssClass="rbPrevious" />
        </telerik:RadButton>
    </div>

    <div style="margin-bottom: 10px;">
        Nội dung bầu cử:
        <asp:Label ID="lblVOTName" runat="server" Font-Bold="true" />
        <br />
        Nội dung bình chọn:
        <asp:Label ID="lblQUEContent" runat="server" Font-Bold="true" />
    </div>

    
    <Partial:RGAnswer ID="RGAnswer" runat="server" />
</asp:Content>
