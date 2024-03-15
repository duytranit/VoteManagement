using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.Barcode;
using Telerik.Web.UI.Skins;

namespace VoteManagement.Partials.Answer
{
    public partial class RGAnswer : System.Web.UI.UserControl
    {
        private string gridMessage = null;
        private int _questionID;
        public int QuestionID
        {
            set
            {
                _questionID = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
                this.Load_RGAnswer_DataSource();
        }
        protected void rgAnswer_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            Models.Entities.Answer ettAnswer = new Models.Entities.Answer();
            ettAnswer.Load_AnswerByQuestionID_RadGrid_WithoutDataBind(rgAnswer, _questionID);
        }
        protected void rgAnswer_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            this.Load_RGAnswer_DataSource();
        }

        protected void rgAnswer_PageSizeChanged(object sender, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
        {
            this.Load_RGAnswer_DataSource();
        }
        protected void rgAnswer_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            Helpers.Telerik hlpTelerik = new Helpers.Telerik();
            hlpTelerik.SetSequenceNumberColumn(rgAnswer, e, "lblSTT");
        }

        protected void rgAnswer_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {            
            GridEditableItem editedItem = e.Item as GridEditableItem;
            Hashtable InputValues = new Hashtable();
            e.Item.OwnerTableView.ExtractValuesFromItem(InputValues, editedItem);
            string content = InputValues["Content"].ToString();

            Models.Entities.Answer ettAnswer = new Models.Entities.Answer();
            ettAnswer.Insert(_questionID, content);

            this.Load_RGAnswer_DataSource();

        }
        protected void rgAnswer_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            int id = (int)editedItem.GetDataKeyValue("ID");
            Hashtable InputValues = new Hashtable();
            e.Item.OwnerTableView.ExtractValuesFromItem(InputValues, editedItem);
            string content = InputValues["Content"].ToString();

            Models.Entities.Answer ettAnswer = new Models.Entities.Answer();
            ettAnswer.Update(id, content);
        }
        protected void rgAnswer_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            int id = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"];

            Models.Entities.Answer ettAnswer = new Models.Entities.Answer();
            ettAnswer.Delete(id);
            //this.Load_RGAnswer_DataSource();
        }
        protected void rgAnswer_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            Helpers.Telerik hlpTelerik = new Helpers.Telerik();
            hlpTelerik.RadGridFilterTextbox(e, "Content", "Câu trả lời");
        }
        private void Load_RGAnswer_DataSource()
        {
            Models.Entities.Answer ettAnswer = new Models.Entities.Answer();
            ettAnswer.Load_AnswerByQuestionID_RadGrid(rgAnswer, _questionID);
        }       
        protected void rgAnswer_ItemInserted(object sender, Telerik.Web.UI.GridInsertedEventArgs e)
        {
            if (e.Exception != null)
            {
                e.ExceptionHandled = true;
                SetMessage("Customer cannot be inserted. Reason: " + e.Exception.Message);
            }
            else
            {
                SetMessage("New customer is inserted!");
            }
        }
        protected void rgAnswer_PreRender(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(gridMessage))
            {
                DisplayMessage(gridMessage);
            }
        }
        private void DisplayMessage(string text)
        {
            rgAnswer.Controls.Add(new LiteralControl(string.Format("<span style='color:red'>{0}</span>", text)));
        }
        private void SetMessage(string message)
        {
            gridMessage = message;
        }
    }
}