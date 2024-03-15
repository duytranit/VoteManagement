<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RGQuestionOfAccount.ascx.cs" Inherits="VoteManagement.Partials.Question.RGQuestionOfAccount" %>

<telerik:RadAjaxManager ID="RadAjaxManager" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgQuestion">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgQuestion" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>

<telerik:RadGrid ID="rgQuestion" runat="server" EnableLinqExpressions="false" AutoGenerateColumns="false"
    ShowStatusBar="true"
    AllowFilteringByColumn="true" AllowSorting="true" AllowPaging="true"
    OnNeedDataSource="rgQuestion_NeedDataSource"
    OnPageIndexChanged="rgQuestion_PageIndexChanged"
    OnPageSizeChanged="rgQuestion_PageSizeChanged"
    OnItemCreated="rgQuestion_ItemCreated"
    OnItemDataBound="rgQuestion_ItemDataBound"
    OnItemCommand="rgQuestion_ItemCommand">
    <HeaderStyle HorizontalAlign="Center" Font-Bold="true" />
    <MasterTableView NoMasterRecordsText="Không tìm thấy dữ liệu phù hợp" DataKeyNames="ID" EditMode="PopUp" CommandItemDisplay="Top">
        <CommandItemSettings ShowAddNewRecordButton="false" />
        <Columns>
            <telerik:GridTemplateColumn HeaderText="STT" AllowFiltering="false" ShowFilterIcon="false" ShowSortIcon="true">
                <ItemTemplate>
                    <asp:Label ID="lblSTT" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="20px" />
            </telerik:GridTemplateColumn>
            <telerik:GridBoundColumn HeaderText="Nội dung" DataField="Content"
                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                ShowFilterIcon="false" ShowSortIcon="true"></telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Đã bình chọn" DataField="ANSContent"
                AllowFiltering="false" AllowSorting="false"></telerik:GridBoundColumn>
            <telerik:GridEditCommandColumn HeaderText="Bình chọn" UniqueName="EditCommandColumn">
                <ItemStyle HorizontalAlign="Center" Width="70px" />
            </telerik:GridEditCommandColumn>
        </Columns>
        <EditFormSettings UserControlName="~\Partials\Question\AnswerQuestion.ascx" EditFormType="WebUserControl">
            <EditColumn UniqueName="EditCommandColumn1">
            </EditColumn>
        </EditFormSettings>
    </MasterTableView>
</telerik:RadGrid>