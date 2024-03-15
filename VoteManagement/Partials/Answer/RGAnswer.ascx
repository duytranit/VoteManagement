<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RGAnswer.ascx.cs" Inherits="VoteManagement.Partials.Answer.RGAnswer" %>

<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgAnswer">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgAnswer" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />

<telerik:RadGrid RenderMode="Lightweight" ID="rgAnswer" runat="server"
    AllowPaging="True" AllowAutomaticUpdates="True" AllowAutomaticInserts="True"
    AllowAutomaticDeletes="true" AllowSorting="true" OnItemCreated="rgAnswer_ItemCreated"
    OnNeedDataSource="rgAnswer_NeedDataSource"
    OnItemDataBound="rgAnswer_ItemDataBound"
    OnPageIndexChanged="rgAnswer_PageIndexChanged"
    OnPageSizeChanged="rgAnswer_PageSizeChanged"
    OnItemInserted="rgAnswer_ItemInserted" OnPreRender="rgAnswer_PreRender" OnInsertCommand="rgAnswer_InsertCommand"
    OnUpdateCommand="rgAnswer_UpdateCommand"
    OnDeleteCommand="rgAnswer_DeleteCommand">
    <PagerStyle Mode="NextPrevAndNumeric" />
    <MasterTableView AutoGenerateColumns="False"
        DataKeyNames="ID" CommandItemDisplay="Top">
        <Columns>            
            <telerik:GridTemplateColumn HeaderText="STT" AllowFiltering="false" ShowFilterIcon="false" ShowSortIcon="true">
                <ItemTemplate>
                    <asp:Label ID="lblSTT" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="20px" />
            </telerik:GridTemplateColumn>
            <telerik:GridBoundColumn HeaderText="Nội dung" DataField="Content"
                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                ShowFilterIcon="false" ShowSortIcon="true">
            </telerik:GridBoundColumn>
            <telerik:GridEditCommandColumn UniqueName="EditCommandColumn">
                <ItemStyle Width="20px" />
            </telerik:GridEditCommandColumn>
            <telerik:GridButtonColumn CommandName="Delete" UniqueName="DeleteColumn" ConfirmText="Bạn có muốn xóa nội dung này không?">
                <ItemStyle Width="20px" />
            </telerik:GridButtonColumn>
        </Columns>
    </MasterTableView>
</telerik:RadGrid>