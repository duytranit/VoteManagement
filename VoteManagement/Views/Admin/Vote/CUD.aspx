<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CUD.aspx.cs" Inherits="VoteManagement.Views.Admin.Vote.CUD" %>
<%@ Register TagPrefix="Partial" TagName="RGQuestion" Src="~/Partials/Question/RGQuestion.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTitle" runat="server">
    QUẢN LÝ BẦU CỬ
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div style="height: 50px;padding-top: 15px; padding-left: 10px;background-color:gainsboro;">
        <telerik:RadButton ID="btPrevious" runat="server" Text="Trở về" PostBackUrl="~/Vote">
            <Icon PrimaryIconCssClass="rbPrevious" />
        </telerik:RadButton>
        <telerik:RadButton ID="btExport" runat="server" Text="Export" OnClick="btExport_Click">
            <Icon PrimaryIconCssClass="rbDownload" />
        </telerik:RadButton>
    </div>

    <div style="margin-bottom: 10px;">
        Nội dung bầu cử:
        <asp:Label ID="lblName" runat="server" Font-Bold="true" />
    </div>
    
    <Partial:RGQuestion ID="RGQuestion" runat="server" />
</asp:Content>
