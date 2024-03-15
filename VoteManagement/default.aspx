<%@ Page Title="Mail" MetaDescription="Telerik WebMail" MetaKeywords="telerik webmail,webmail,outlook inspired app" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="VoteManagement.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FolderContent" runat="server">
    <telerik:RadCalendar ID="cldDate" runat="server"></telerik:RadCalendar>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td style="width: 50%; text-align:right;">
                Tài khoản:
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername"
                    ErrorMessage="(*)" ToolTip="Nhập tài khoản đăng nhập" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                <telerik:RadTextBox ID="txtUsername" runat="server" EmptyMessage="Tài khoản" EmptyMessageStyle-BorderColor="Red"></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:right;">
                Mật khẩu:
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="(*)" ToolTip="Nhập mật khẩu đăng nhập" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
            </td>
            <td>
                <telerik:RadTextBox ID="txtPassword" runat="server" TextMode="Password" EmptyMessageStyle-BorderColor="Red"></telerik:RadTextBox>
            </td>
        </tr>
    </table>
    <div style="width: 100%; text-align: center; margin-top: 20px;">
        <telerik:RadButton ID="btLogin" runat="server" Text="Đăng nhập" OnClick="btLogin_Click"></telerik:RadButton>
    </div>
</asp:Content>
