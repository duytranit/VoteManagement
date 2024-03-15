using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VoteManagement.Partials.Department;

namespace VoteManagement.Partials.Account
{
    public partial class RGAccount : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.Page.IsPostBack)
                this.Load_RGAccount_DataSouce();
        }

        protected void rgAccount_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            this.Load_RGAccount_DataSouce();
        }

        protected void rgAccount_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            Helpers.Telerik hlpTelerik = new Helpers.Telerik();
            hlpTelerik.SetSequenceNumberColumn(rgAccount, e, "lblSTT");
        }

        protected void rgAccount_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            this.Load_RGAccount_DataSouce();
        }

        protected void rgAccount_PageSizeChanged(object sender, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
        {
            this.Load_RGAccount_DataSouce();
        }

        protected void rgAccount_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            Helpers.Telerik hlpTelerik = new Helpers.Telerik();
            hlpTelerik.RadGridFilterTextbox(e, "Username", "Tài khoản");
            hlpTelerik.RadGridFilterTextbox(e, "Name", "Họ và tên");
            hlpTelerik.RadGridFilterTextbox(e, "ACCName", "Loại tài khoản");
        }
        private void Load_RGAccount_DataSouce()
        {
            Models.Entities.Account ettAccount = new Models.Entities.Account();
            ettAccount.Load_Accounts_ToRadGrid(rgAccount);
        }

        protected void rgAccount_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                rgAccount.MasterTableView.EditFormSettings.CaptionDataField = "Username";
                rgAccount.MasterTableView.EditFormSettings.CaptionFormatString = "Cập nhật tài khoản : {0}";
            }
            else if (e.CommandName == "InitInsert")
            {
                rgAccount.MasterTableView.EditFormSettings.CaptionDataField = "";
                rgAccount.MasterTableView.EditFormSettings.CaptionFormatString = "Tạo mới tài khoản";

            }
        }

        protected void rgAccount_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            int accountID = (int)(e.Item as GridDataItem).OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"];
            Models.Entities.Account ettAccount = new Models.Entities.Account();
            ettAccount.Delete(accountID);
        }
    }
}