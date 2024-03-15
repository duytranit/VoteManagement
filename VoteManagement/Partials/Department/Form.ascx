<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Form.ascx.cs" Inherits="VoteManagement.Partials.Department.Form" %>

<div style="margin: 20px;">
    <asp:Label ID="lblID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ID").ToString() %>' Visible="false"></asp:Label>

    <table style="width:100%;">
        <tr>
            <td>Đơn vị:
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                ErrorMessage="(*)" ToolTip="Nhập tên tên đơn vị" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
            </td>
            <td>
                <telerik:RadTextBox ID="txtName" runat="server" EmptyMessage="Tên đơn vị" EmptyMessageStyle-BorderColor="Red" Width="100%"
                    Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'>
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>Trạng thái:
            </td>
            <td>
                <telerik:RadCheckBox ID="chbStatus" runat="server" Text="Kích hoạt" Checked='<%# DataBinder.Eval(Container, "DataItem.Status") %>'></telerik:RadCheckBox>
            </td>
        </tr>
    </table>

    <div style="width: 100%; text-align: center; margin-top: 20px;">
        <telerik:RadButton ID="btSubmit" runat="server" Text="Hoàn tất" OnClick="btSubmit_Click">
            <Icon PrimaryIconCssClass="rbOk" />
        </telerik:RadButton>
    </div>
</div>
