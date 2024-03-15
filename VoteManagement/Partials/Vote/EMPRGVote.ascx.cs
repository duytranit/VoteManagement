using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VoteManagement.Partials.Vote
{
    public partial class EMPRGVote : System.Web.UI.UserControl
    {
        private int _accountID;
        public int AccountID { set { _accountID = value; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
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
            ettVote.Load_Vote_OfAccount_RadGrid(rgVote, _accountID);
        }

        protected void rgVote_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            Helpers.Telerik hlpTelerik = new Helpers.Telerik();
            hlpTelerik.RadGridFilterTextbox(e, "Name", "Nhập bầu cử");
            hlpTelerik.RadGridFilterTextbox(e, "Description", "Nhập thông tin bầu cử");
            hlpTelerik.RadGridFilterTextbox(e, "Date", "Nhập ngày tháng");
        }
    }
}