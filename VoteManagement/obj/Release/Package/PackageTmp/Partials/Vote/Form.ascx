<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Form.ascx.cs" Inherits="VoteManagement.Partials.Vote.Form" %>

<div style="margin: 20px;">
    <asp:Label ID="lblID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.ID") %>' />

    <table style="width: 100%;">
        <tr>
            <td>Bộ phận:
            <asp:RequiredFieldValidator ID="rfvDepartment" runat="server" ControlToValidate="cbbDepartment"
                ErrorMessage="(*)" ToolTip="Nhập bộ phận" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                <telerik:RadComboBox ID="cbbDepartment" runat="server" EmptyMessage="Chọn bộ phận" Filter="Contains"
                    DataSourceID="SqlDataSourceDepartment" DataValueField="ID" DataTextField="Name"
                    SelectedValue='<%# DataBinder.Eval(Container, "DataItem.DPTID") %>'></telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>Tên:
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                ErrorMessage="(*)" ToolTip="Nhập tên cuộc bỏ phiếu" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                <telerik:RadTextBox ID="txtName" runat="server" EmptyMessage="Tên cuộc bỏ phiếu" EmptyMessageStyle-BorderColor="Red"
                    Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>Thông tin chi tiết:
            </td>
            <td>
                <telerik:RadTextBox ID="txtDescription" runat="server" TextMode="MultiLine"
                    EmptyMessage="Thông tin chi tiết" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>'>
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>Ngày tháng bỏ phiếu:
            <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="dpkDate"
                ErrorMessage="(*)" ToolTip="Nhập ngày bỏ phiếu" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cpvDate" runat="server" ControlToValidate="dpkDate" Operator="DataTypeCheck" Type="Date"
                    ErrorMessage="(*)" ToolTip="Ngày tháng bỏ phiếu có giá trị không thích hợp" Font-Bold="true" ForeColor="Red"></asp:CompareValidator>
            </td>
            <td>
                <telerik:RadDatePicker ID="dpkDate" runat="server" Culture="vi-VN" Calendar-Culture="vi-VN"
                    DateInput-EmptyMessage="dd/MM/yyyy" DateInput-EmptyMessageStyle-BorderColor="Red"
                    DbSelectedDate='<%# DataBinder.Eval(Container, "DataItem.Date") %>'>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td>Trạng thái:
            </td>
            <td>
                <telerik:RadCheckBox ID="chbStatus" runat="server" Text="Kích hoạt" 
                    Checked='<%# DataBinder.Eval(Container, "DataItem.Status") %>'></telerik:RadCheckBox>
            </td>
        </tr>
    </table>
    <div style="width: 100%; text-align: center;">
        <telerik:RadButton ID="btSubmit" runat="server" Text="Hoàn tất" OnClick="btSubmit_Click">
            <Icon PrimaryIconCssClass="rbOk" />
        </telerik:RadButton>
    </div>
</div>

<asp:SqlDataSource runat="server" ID="SqlDataSourceDepartment" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Department]" />