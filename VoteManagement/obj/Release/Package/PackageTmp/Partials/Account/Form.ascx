<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Form.ascx.cs" Inherits="VoteManagement.Partials.Account.Form" %>

<div style="margin: 20px;">
    <asp:Label ID="lblID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.ID") %>' />

    <table style="width: 100%">
        <tr>
            <td>
                Đơn vị:
                <asp:RequiredFieldValidator ID="rfvDepartment" runat="server" ControlToValidate="cbbDepartment" Display="Dynamic"
                    ErrorMessage="(*)" ToolTip="Chọn đơn vị" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
            </td>
            <td>
                <telerik:RadComboBox ID="cbbDepartment" runat="server" EmptyMessage="Chọn đơn vị"
                    DataSourceID="SqlDataSourceDepartment" DataValueField="ID" DataTextField="Name"
                    SelectedValue='<%# DataBinder.Eval(Container, "DataItem.DPMID") %>' Width="100%"></telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>Loại tài khoản:
    <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="cbbCategory" Display="Dynamic"
        ErrorMessage="(*)" ToolTip="Chọn loại tài khoản" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
            </td>
            <td>
                <telerik:RadComboBox ID="cbbCategory" runat="server" EmptyMessage="Chọn loại tài khoản"
                    DataSourceID="SqlDataSourceAccountCategory" DataTextField="Name" DataValueField="ID"
                    SelectedValue='<%# DataBinder.Eval(Container, "DataItem.ACCID") %>' Width="100%">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>Nhân viên:
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic"
                ErrorMessage="(*)" ToolTip="Nhập họ và tên nhân viên" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
            </td>
            <td>
                <telerik:RadTextBox ID="txtName" runat="server" EmptyMessage="Họ và tên nhân viên" EmptyMessageStyle-BorderColor="Red"
                    Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>' Width="100%">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>Tài khoản:
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" Display="Dynamic"
                ErrorMessage="(*)" ToolTip="Nhập tài khoản" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                <telerik:RadTextBox ID="txtUsername" runat="server" EmptyMessage="Tài khoản" EmptyMessageStyle-BorderColor="Red"
                    Text='<%# DataBinder.Eval(Container, "DataItem.Username") %>' Width="100%">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>Mật khẩu:
            </td>
            <td>
                <telerik:RadTextBox ID="txtPassword" runat="server" TextMode="Password" EmptyMessageStyle-BorderColor="Red" Width="100%"></telerik:RadTextBox>
            </td>
        </tr>        
        <tr>
            <td>Trạng thái:
            </td>
            <td>
                <telerik:RadCheckBox ID="chbStatus" runat="server" Text="Kích hoạt" Checked='<%# DataBinder.Eval(Container, "DataItem.Status") %>' />
            </td>
        </tr>
    </table>
    <div style="width: 100%; text-align: center;">
        <telerik:RadButton ID="btSubmit" runat="server" Text="Hoàn tất" OnClick="btSubmit_Click">
            <Icon PrimaryIconCssClass="rbOk" />
        </telerik:RadButton>
    </div>
</div>

<asp:SqlDataSource runat="server" ID="SqlDataSourceAccountCategory" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [AccountCategory]" />
<asp:SqlDataSource runat="server" ID="SqlDataSourceDepartment" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Department]" />

