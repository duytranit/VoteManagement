<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RGDepartment.ascx.cs" Inherits="VoteManagement.Partials.Department.RGDepartment" %>

<telerik:RadAjaxManager ID="RadAjaxManager" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgDepartment">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgDepartment" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>

<telerik:RadGrid ID="rgDepartment" runat="server" EnableLinqExpressions="false" AutoGenerateColumns="false"
    ShowStatusBar="true"
    AllowFilteringByColumn="true" AllowSorting="true" AllowPaging="true"
    OnNeedDataSource="rgDepartment_NeedDataSource"
    OnPageIndexChanged="rgDepartment_PageIndexChanged"
    OnPageSizeChanged="rgDepartment_PageSizeChanged"
    OnItemDataBound="rgDepartment_ItemDataBound"
    OnItemCreated="rgDepartment_ItemCreated"
    OnItemCommand="rgDepartment_ItemCommand"
    OnDeleteCommand="rgDepartment_DeleteCommand">
    <HeaderStyle HorizontalAlign="Center" Font-Bold="true" />
    <MasterTableView NoMasterRecordsText="Không tìm thấy dữ liệu phù hợp" DataKeyNames="ID" EditMode="PopUp" CommandItemDisplay="Top">
        <Columns>
            <telerik:GridTemplateColumn HeaderText="STT" AllowFiltering="false" ShowFilterIcon="false" ShowSortIcon="true">
                <ItemTemplate>
                    <asp:Label ID="lblSTT" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="20px" />
            </telerik:GridTemplateColumn>
            <telerik:GridBoundColumn HeaderText="Đơn vị" DataField="Name"
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
            <telerik:GridButtonColumn HeaderText="Delete" UniqueName="DeleteColumn" Text="Delete" CommandName="Delete" ConfirmText="Bạn có muốn xóa đơn vị này không?">
                <ItemStyle HorizontalAlign="Center" Width="70px" />
            </telerik:GridButtonColumn>            
        </Columns>
        <EditFormSettings UserControlName="~\Partials\Department\Form.ascx" EditFormType="WebUserControl">
            <EditColumn UniqueName="EditCommandColumn1">
            </EditColumn>
        </EditFormSettings>
    </MasterTableView>
</telerik:RadGrid>