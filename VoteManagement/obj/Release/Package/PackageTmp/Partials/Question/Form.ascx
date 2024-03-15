<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Form.ascx.cs" Inherits="VoteManagement.Partials.Question.Form" %>

<div style="margin: 20px;">
    <asp:Label ID="lblID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ID").ToString() %>' Visible="false"></asp:Label>
    <table style="width:100%;">
        <tr>
            <td colspan="2">
                Bỏ phiếu:
                <asp:Label ID="lblVOTName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Nội dung:
            <asp:RequiredFieldValidator ID="rfvContent" runat="server" ControlToValidate="txtContent"
                ErrorMessage="(*)" ToolTip="Nhập nội dung" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
            </td>
            <td>
                <telerik:RadTextBox ID="txtContent" runat="server" TextMode="MultiLine" EmptyMessage="Nội dung" Width="100%"
                    EmptyMessageStyle-BorderColor="Red" Text='<%# DataBinder.Eval(Container, "DataItem.Content") %>'>
                </telerik:RadTextBox>
            </td>
        </tr>
    </table>
    <div style="width: 100%; text-align: center; margin-top: 20px;">
        <telerik:RadButton ID="btSubmit" runat="server" Text="Hoàn tất" OnClick="btSubmit_Click">
            <Icon PrimaryIconCssClass="rbOk" />
        </telerik:RadButton>
    </div>
</div>

