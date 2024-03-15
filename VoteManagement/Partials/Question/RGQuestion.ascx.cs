using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VoteManagement.Partials.Department;

namespace VoteManagement.Partials.Question
{
    public partial class RGQuestion : System.Web.UI.UserControl
    {
        private int _voteID;
        public int VoteID { set { _voteID = value; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
                this.Load_DataSource_RadGridQuestion();
        }

        protected void rgQuestion_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            this.Load_DataSource_RadGridQuestion();
        }

        protected void rgQuestion_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            this.Load_DataSource_RadGridQuestion();
        }

        protected void rgQuestion_PageSizeChanged(object sender, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
        {
            this.Load_DataSource_RadGridQuestion();
        }

        protected void rgQuestion_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            Helpers.Telerik hlpTelerik = new Helpers.Telerik();
            hlpTelerik.SetSequenceNumberColumn(rgQuestion, e, "lblSTT");
        }

        protected void rgQuestion_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            Helpers.Telerik hlpTelerik = new Helpers.Telerik();
            hlpTelerik.RadGridFilterTextbox(e, "Content", "Nội dung bình chọn");
        }
        private void Load_DataSource_RadGridQuestion()
        {
            Models.Entities.Question ettQuestion = new Models.Entities.Question();
            ettQuestion.Load_QuestionOfVote_ToRadGrid(rgQuestion, _voteID);
        }

        protected void rgQuestion_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                rgQuestion.MasterTableView.EditFormSettings.CaptionDataField = "Content";
                rgQuestion.MasterTableView.EditFormSettings.CaptionFormatString = "Cập nhật câu hỏi: {0}";
            }
            else if (e.CommandName == "InitInsert")
            {
                rgQuestion.MasterTableView.EditFormSettings.CaptionDataField = "";
                rgQuestion.MasterTableView.EditFormSettings.CaptionFormatString = "Tạo mới câu hỏi";

            }
        }

        protected void rgQuestion_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            int questionID = (int)(e.Item as GridDataItem).OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"];
            Models.Entities.Question ettQuestion = new Models.Entities.Question();
            ettQuestion.Delete(questionID);
        }
    }
}