<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="VoteManagement.Views.Admin.Answer.Index" %>
<%@ Register TagPrefix="Partial" TagName="RGAnswer" Src="~/Partials/Answer/RGAnswer.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadNavigation runat="server" ID="contactNavigation" Skin="BlackMetroTouch" CssClass="secondaryMenu">
        <Nodes>
            <telerik:NavigationNode Text="Tạo mới" SpriteCssClass="icon icon-Add-Circle" NavigateUrl="~/Answer/TaoMoi">
            </telerik:NavigationNode>
        </Nodes>
    </telerik:RadNavigation>
    <Partial:RGAnswer ID="rgAnswer" runat="server" />
</asp:Content>
