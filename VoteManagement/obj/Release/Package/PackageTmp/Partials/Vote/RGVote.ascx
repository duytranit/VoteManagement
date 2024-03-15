<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RGVote.ascx.cs" Inherits="VoteManagement.Partials.Vote.RGVote" %>
<telerik:RadAjaxManager ID="RadAjaxManager" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgVote">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgVote" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>

<telerik:RadGrid ID="rgVote" runat="server" EnableLinqExpressions="false" AutoGenerateColumns="false"
    ShowStatusBar="true"
    AllowPaging="true" AllowSorting="true" AllowFilteringByColumn="true"
    OnNeedDataSource="rgVote_NeedDataSource"
    OnPageIndexChanged="rgVote_PageIndexChanged"
    OnPageSizeChanged="rgVote_PageSizeChanged"
    OnItemDataBound="rgVote_ItemDataBound"
    OnItemCreated="rgVote_ItemCreated"
    OnItemCommand="rgVote_ItemCommand"
    OnDeleteCommand="rgVote_DeleteCommand">
    <HeaderStyle Font-Bold="true" HorizontalAlign="Center" />
    <MasterTableView NoMasterRecordsText="Không tìm thấy dữ liệu phù hợp" DataKeyNames="ID" EditMode="PopUp" CommandItemDisplay="Top">
        <Columns>
            <telerik:GridTemplateColumn HeaderText="STT" AllowFiltering="false" ShowFilterIcon="false" ShowSortIcon="true">
                <ItemTemplate>
                    <asp:Label ID="lblSTT" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="20px" />
            </telerik:GridTemplateColumn>
            <telerik:GridHyperLinkColumn HeaderText="Nội dung" DataTextField="Name"
                DataNavigateUrlFields="ID" DataNavigateUrlFormatString="~/Vote/{0}"
                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                ShowFilterIcon="false" ShowSortIcon="true"></telerik:GridHyperLinkColumn>
            <telerik:GridBoundColumn HeaderText="Thông tin" DataField="Description"
                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                ShowFilterIcon="false" ShowSortIcon="true"></telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Ngày tháng" DataField="Date"
                DataFormatString="{0:dd/MM/yyyy}"
                ShowFilterIcon="false" ShowSortIcon="true">
                <ItemStyle HorizontalAlign="Center" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Tổ chức" DataField="DPTName"
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
            <telerik:GridButtonColumn HeaderText="Delete" UniqueName="DeleteColumn" Text="Delete" CommandName="Delete" ConfirmText="Bạn có muốn xóa bỏ phiếu này không?">
                <ItemStyle HorizontalAlign="Center" Width="70px" />
            </telerik:GridButtonColumn>
        </Columns>
        <EditFormSettings UserControlName="~\Partials\Vote\Form.ascx" EditFormType="WebUserControl">
            <EditColumn UniqueName="EditCommandColumn1">
            </EditColumn>
        </EditFormSettings>
    </MasterTableView>
</telerik:RadGrid>