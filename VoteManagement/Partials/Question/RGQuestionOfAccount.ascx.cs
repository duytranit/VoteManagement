using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VoteManagement.Partials.Department;

namespace VoteManagement.Partials.Question
{
    public partial class RGQuestionOfAccount : System.Web.UI.UserControl
    {
        private int _voteID;
        private int _accountID;
        public int VoteID { set { _voteID = value; }}
        public int AccountID { set { _accountID = value; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) { this.Load_RGQuestion_DataSource(); }
        }

        protected void rgQuestion_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            this.Load_RGQuestion_DataSource();
        }

        protected void rgQuestion_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            this.Load_RGQuestion_DataSource();
        }

        protected void rgQuestion_PageSizeChanged(object sender, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
        {
            this.Load_RGQuestion_DataSource();
        }

        protected void rgQuestion_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            Helpers.Telerik hlpTelerik = new Helpers.Telerik();
            hlpTelerik.RadGridFilterTextbox(e, "Content", "Nội dung bình chọn");
        }

        protected void rgQuestion_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            Helpers.Telerik hlpTelerik = new Helpers.Telerik();
            hlpTelerik.SetSequenceNumberColumn(rgQuestion, e, "lblSTT");
        }
        public void Load_RGQuestion_DataSource()
        {
            Models.Entities.Question ettQuestion = new Models.Entities.Question();
            ettQuestion.Load_Question_ByVote_RadGrid(rgQuestion, _voteID, _accountID);
        }

        protected void rgQuestion_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                rgQuestion.MasterTableView.EditFormSettings.CaptionDataField = "Content";
                rgQuestion.MasterTableView.EditFormSettings.CaptionFormatString = "Bình chọn cho nội dung: {0}";
            }
        }
    }
}