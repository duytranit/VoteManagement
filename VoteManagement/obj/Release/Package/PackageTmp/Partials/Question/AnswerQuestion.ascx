<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AnswerQuestion.ascx.cs" Inherits="VoteManagement.Partials.Question.AnswerQuestion" %>

<div style="margin: 20px;">
    <asp:Label ID="lblID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ID") %>' Visible="false" />
    <asp:Label ID="lblContent" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Content") %>' Font-Bold="true" />
    <telerik:RadDropDownList ID="ddlAnswer" runat="server" DataSourceID="SqlDataSourceAnswer" Width="100%"
        DataTextField="Content" DataValueField="ID" SelectedValue='<%# DataBinder.Eval(Container, "DataItem.ANSID") %>'/>'
    <div style="width: 100%; text-align: center; margin-top: 20px;">
        <telerik:RadButton ID="btSubmit" runat="server" Text="Hoàn tất" OnClick="btSubmit_Click">
            <Icon PrimaryIconCssClass="rbOk" />
        </telerik:RadButton>
    </div>
</div>
<asp:SqlDataSource runat="server" ID="SqlDataSourceAnswer" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand='<%# DataBinder.Eval(Container, "DataItem.SelectCommandAnswer") %>'/>