using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VoteManagement.Partials.Answer;

namespace VoteManagement.Partials.Question
{
    public partial class AnswerQuestion : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            int answerID = Convert.ToInt32(ddlAnswer.SelectedValue);
            int accountID = Convert.ToInt32(this.Session["accountID"]);
            int questionID = Convert.ToInt32(lblID.Text);

            Models.Entities.AccountAnswer ettAccountAnswer = new Models.Entities.AccountAnswer();
            ettAccountAnswer.Delete_ByQuestionID_AccountID(questionID, accountID);
            ettAccountAnswer.Insert(accountID, answerID);

            Response.Redirect(Request.RawUrl);
        }
    }
}