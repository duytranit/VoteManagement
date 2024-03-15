using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.Skins;

namespace VoteManagement.Partials.Department
{
    public partial class RGDepartment : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
                this.Load_RGDepartment_DataSource();
        }

        protected void rgDepartment_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            this.Load_RGDepartment_DataSource();
        }

        protected void rgDepartment_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            this.Load_RGDepartment_DataSource();
        }

        protected void rgDepartment_PageSizeChanged(object sender, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
        {
            this.Load_RGDepartment_DataSource();
        }

        protected void rgDepartment_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            Helpers.Telerik hlpTelerik = new Helpers.Telerik();
            hlpTelerik.SetSequenceNumberColumn(rgDepartment, e, "lblSTT");
        }

        protected void rgDepartment_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            Helpers.Telerik hlpTelerik = new Helpers.Telerik();
            hlpTelerik.RadGridFilterTextbox(e, "Name", "Đơn vị");
        }
        public void Load_RGDepartment_DataSource()
        {
            Models.Entities.Department ettDepartment = new Models.Entities.Department();
            ettDepartment.Load_AllDepartment_RadGrid(rgDepartment);
        }

        protected void rgDepartment_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            int departmentID = (int)(e.Item as GridDataItem).OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"];
            Models.Entities.Department ettDepartment = new Models.Entities.Department();
            ettDepartment.Delete(departmentID);
        }

        protected void rgDepartment_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                rgDepartment.MasterTableView.EditFormSettings.CaptionDataField = "Name";
                rgDepartment.MasterTableView.EditFormSettings.CaptionFormatString = "Cập nhật đơn vị : {0}";
            }
            else if (e.CommandName == "InitInsert")
            {
                rgDepartment.MasterTableView.EditFormSettings.CaptionDataField = "";
                rgDepartment.MasterTableView.EditFormSettings.CaptionFormatString = "Tạo mới đơn vị";

            }
        }
    }
}