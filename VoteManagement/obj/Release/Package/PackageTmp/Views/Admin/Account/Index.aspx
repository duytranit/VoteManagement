<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="VoteManagement.Views.Admin.Account.Index" %>
<%@ Register TagPrefix="Partial" TagName="RGAccount" Src="~/Partials/Account/RGAccount.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="pageTitle" runat="server">
    QUẢN LÝ TÀI KHOẢN
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadNavigation runat="server" ID="contactNavigation" Skin="BlackMetroTouch" CssClass="secondaryMenu">
        <Nodes>
            <telerik:NavigationNode Text="Tạo mới" SpriteCssClass="icon icon-Add-Circle" NavigateUrl="~/Account/TaoMoi">
            </telerik:NavigationNode>
        </Nodes>
    </telerik:RadNavigation>
    <Partial:RGAccount runat="server" />
</asp:Content>
