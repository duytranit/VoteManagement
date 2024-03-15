<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RGQuestion.ascx.cs" Inherits="VoteManagement.Partials.Question.RGQuestion" %>

<telerik:RadAjaxManager ID="RadAjaxManager" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgQuestion">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgQuestion" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>

<telerik:RadGrid ID="rgQuestion" runat="server" AutoGenerateColumns="false" EnableLinqExpressions="false"
    ShowStatusBar="true"
    AllowFilteringByColumn="true" AllowSorting="true" AllowPaging="true"
    OnNeedDataSource="rgQuestion_NeedDataSource"
    OnPageIndexChanged="rgQuestion_PageIndexChanged"
    OnPageSizeChanged="rgQuestion_PageSizeChanged"
    OnItemDataBound="rgQuestion_ItemDataBound"
    OnItemCreated="rgQuestion_ItemCreated"
    OnItemCommand="rgQuestion_ItemCommand"
    OnDeleteCommand="rgQuestion_DeleteCommand">
    <HeaderStyle Font-Bold="true" HorizontalAlign="Center" />
    <MasterTableView NoMasterRecordsText="Không tìm thấy dữ liệu phù hợp" DataKeyNames="ID" EditMode="PopUp" CommandItemDisplay="Top">
        <Columns>            
            <telerik:GridTemplateColumn HeaderText="STT" AllowFiltering="false" ShowFilterIcon="false" ShowSortIcon="false">
                <ItemTemplate>
                    <asp:Label ID="lblSTT" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="20px" />
            </telerik:GridTemplateColumn>
            <telerik:GridHyperLinkColumn HeaderText="Nội dung bỏ phiếu" DataTextField="Content"
                DataNavigateUrlFields="ID" DataNavigateUrlFormatString="~/Question/{0}"
                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                ShowFilterIcon="false" ShowSortIcon="true"></telerik:GridHyperLinkColumn>
            <telerik:GridEditCommandColumn HeaderText="Update" UniqueName="EditCommandColumn">
                <ItemStyle HorizontalAlign="Center" Width="70px" />
            </telerik:GridEditCommandColumn>
            <telerik:GridButtonColumn HeaderText="Delete" UniqueName="DeleteColumn" Text="Delete" CommandName="Delete" ConfirmText="Bạn có muốn xóa câu hỏi này không?">
                <ItemStyle HorizontalAlign="Center" Width="70px" />
            </telerik:GridButtonColumn>
        </Columns>
        <EditFormSettings UserControlName="~\Partials\Question\Form.ascx" EditFormType="WebUserControl">
            <EditColumn UniqueName="EditCommandColumn1">
            </EditColumn>
        </EditFormSettings>
    </MasterTableView>
</telerik:RadGrid>