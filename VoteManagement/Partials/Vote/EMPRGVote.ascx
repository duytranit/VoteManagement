<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EMPRGVote.ascx.cs" Inherits="VoteManagement.Partials.Vote.EMPRGVote" %>
<telerik:RadGrid ID="rgVote" runat="server" EnableLinqExpressions="false" AutoGenerateColumns="false"
    AllowPaging="true" AllowSorting="true" AllowFilteringByColumn="true"
    OnNeedDataSource="rgVote_NeedDataSource"
    OnPageIndexChanged="rgVote_PageIndexChanged"
    OnPageSizeChanged="rgVote_PageSizeChanged"
    OnItemDataBound="rgVote_ItemDataBound"
    OnItemCreated="rgVote_ItemCreated">
    <HeaderStyle Font-Bold="true" HorizontalAlign="Center" />
    <MasterTableView NoMasterRecordsText="Không tìm thấy dữ liệu phù hợp">
        <CommandItemSettings ShowAddNewRecordButton="false" />
        <Columns>
            <telerik:GridTemplateColumn HeaderText="STT" AllowFiltering="false" ShowFilterIcon="false" ShowSortIcon="true">
                <ItemTemplate>
                    <asp:Label ID="lblSTT" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="20px" />
            </telerik:GridTemplateColumn>
            <telerik:GridHyperLinkColumn HeaderText="Bỏ phiếu" DataTextField="Name"
                DataNavigateUrlFields="ID" DataNavigateUrlFormatString="~/EMP_AccountAnswer/{0}"
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
        </Columns>
    </MasterTableView>
</telerik:RadGrid>