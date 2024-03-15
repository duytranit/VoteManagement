using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VoteManagement.Partials.Department;

namespace VoteManagement.Partials.Vote
{
    public partial class RGVote : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.Page.IsPostBack)
                this.LoadRGVote_DataSource();
        }

        protected void rgVote_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            this.LoadRGVote_DataSource();
        }

        protected void rgVote_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            this.LoadRGVote_DataSource();
        }

        protected void rgVote_PageSizeChanged(object sender, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
        {
            this.LoadRGVote_DataSource();
        }

        protected void rgVote_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            Helpers.Telerik hlpTelerik = new Helpers.Telerik();
            hlpTelerik.SetSequenceNumberColumn(rgVote, e, "lblSTT");
        }

        private void LoadRGVote_DataSource()
        {
            Models.Entities.Vote ettVote = new Models.Entities.Vote();
            ettVote.Load_AllVote_RadGrid(rgVote);
        }

        protected void rgVote_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            Helpers.Telerik hlpTelerik = new Helpers.Telerik();
            hlpTelerik.RadGridFilterTextbox(e, "Name", "Nhập bầu cử");
            hlpTelerik.RadGridFilterTextbox(e, "Description", "Nhập thông tin bầu cử");
            hlpTelerik.RadGridFilterTextbox(e, "Date", "Nhập ngày tháng");
            hlpTelerik.RadGridFilterTextbox(e, "DPTName", "Nhập đơn vị");
        }

        protected void rgVote_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            int voteID = (int)(e.Item as GridDataItem).OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"];
            Models.Entities.Vote ettVote = new Models.Entities.Vote();
            ettVote.Delete(voteID);
        }

        protected void rgVote_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                rgVote.MasterTableView.EditFormSettings.CaptionDataField = "Name";
                rgVote.MasterTableView.EditFormSettings.CaptionFormatString = "Cập nhật bỏ phiếu: {0}";
            }
            else if (e.CommandName == "InitInsert")
            {
                rgVote.MasterTableView.EditFormSettings.CaptionDataField = "";
                rgVote.MasterTableView.EditFormSettings.CaptionFormatString = "Tạo mới bỏ phiếu";

            }
        }
    }
}