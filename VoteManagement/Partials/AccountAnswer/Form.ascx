<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Form.ascx.cs" Inherits="VoteManagement.Partials.AccountAnswer.Form" %>
<asp:Label ID="lblQuestion" runat="server" Font-Bold="true" Font-Italic="true"></asp:Label>
<br />
<telerik:RadRadioButtonList ID="rblAnswer" runat="server"></telerik:RadRadioButtonList>

<div style="width: 100%; text-align: center;">
    <telerik:RadButton ID="btSubmit" runat="server" Text="OK" OnClick="btSubmit_Click">
        <Icon PrimaryIconCssClass="rbOk" />
    </telerik:RadButton>
</div>