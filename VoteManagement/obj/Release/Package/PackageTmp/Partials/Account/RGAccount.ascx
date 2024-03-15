<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RGAccount.ascx.cs" Inherits="VoteManagement.Partials.Account.RGAccount" %>

<telerik:RadAjaxManager ID="RadAjaxManager" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgAccount">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgAccount" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>

<telerik:RadGrid ID="rgAccount" runat="server" EnableLinqExpressions="false" AutoGenerateColumns="false"
    ShowStatusBar="true"
    AllowFilteringByColumn="true" AllowSorting="true" AllowPaging="true"
    OnNeedDataSource="rgAccount_NeedDataSource"
    OnItemDataBound="rgAccount_ItemDataBound"
    OnPageIndexChanged="rgAccount_PageIndexChanged"
    OnPageSizeChanged="rgAccount_PageSizeChanged"
    OnItemCreated="rgAccount_ItemCreated"
    OnItemCommand="rgAccount_ItemCommand"
    OnDeleteCommand="rgAccount_DeleteCommand">
    <HeaderStyle HorizontalAlign="Center" Font-Bold="true" />
    <MasterTableView NoMasterRecordsText="Không tìm thấy dữ liệu phù hợp" DataKeyNames="ID" EditMode="PopUp" CommandItemDisplay="Top">
        <Columns>
            <telerik:GridTemplateColumn HeaderText="STT" AllowFiltering="false" ShowFilterIcon="false" ShowSortIcon="true">
                <ItemTemplate>
                    <asp:Label ID="lblSTT" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="20px" />
            </telerik:GridTemplateColumn>
            <telerik:GridBoundColumn HeaderText="Tài khoản" DataField="Username"
                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                ShowFilterIcon="false" ShowSortIcon="true"></telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Nhân viên" DataField="Name"
                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                ShowFilterIcon="false" ShowSortIcon="true"></telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Loại tài khoản" DataField="ACCName"
                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                ShowFilterIcon="false" ShowSortIcon="true"></telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Trạng thái" DataField="Status">
                <FilterTemplate>
                    <telerik:RadComboBox ID="cbbSearchStatus" runat="server" AppendDataBoundItems="true" Width="100%"
                        SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("Status").CurrentFilterValue %>'
                        OnClientSelectedIndexChanged="SelectedIndexChanged_Status">
                        <Items>
                            <telerik:RadComboBoxItem Text="All" />
                            <telerik:RadComboBoxItem Text="True" Value="True" />
                            <telerik:RadComboBoxItem Text="False" Value="False" />
                        </Items>
                    </telerik:RadComboBox>
                    <telerik:RadScriptBlock ID="SelectedIndexChanged_Status" runat="server">
                        <script type="text/javascript">
                            function SelectedIndexChanged_Status(sender, args) {
                                var tableview = $find("<%# ((GridItem)Container).OwnerTableView.ClientID %>");
                                tableview.filter("Status", args.get_item().get_value(), "EqualTo");
                            }
                        </script>
                    </telerik:RadScriptBlock>
                </FilterTemplate>
                <ItemStyle Width="150px" HorizontalAlign="Center" />
            </telerik:GridBoundColumn>
            <telerik:GridEditCommandColumn HeaderText="Update" UniqueName="EditCommandColumn">
                <ItemStyle HorizontalAlign="Center" Width="70px" />
            </telerik:GridEditCommandColumn>
            <telerik:GridButtonColumn HeaderText="Delete" UniqueName="DeleteColumn" Text="Delete" CommandName="Delete" ConfirmText="Bạn có muốn xóa tài khoản này không?">
                <ItemStyle HorizontalAlign="Center" Width="70px" />
            </telerik:GridButtonColumn>
        </Columns>
        <EditFormSettings UserControlName="~\Partials\Account\Form.ascx" EditFormType="WebUserControl">
            <EditColumn UniqueName="EditCommandColumn1">
            </EditColumn>
        </EditFormSettings>
    </MasterTableView>
</telerik:RadGrid>