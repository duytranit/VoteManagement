using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VoteManagement.Partials.AccountAnswer
{
    public partial class Form : System.Web.UI.UserControl
    {
        private int _questionID;
        private int _accountID;
        public int QuestionID { set { _questionID = value; } }
        public int AccountID { set { _accountID = value; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                Models.Entities.Question ettQuestion = new Models.Entities.Question();
                Models.Question question = ettQuestion.Find(_questionID);
                lblQuestion.Text = question.Content;

                Models.Entities.Answer ettAnswer = new Models.Entities.Answer();
                ettAnswer.Load_AnswerByQuestionID_RadRadioButtonList(rblAnswer, _questionID);

                Models.Entities.AccountAnswer ettAccountAnswer = new Models.Entities.AccountAnswer();
                Models.AccounAnswer accAnswer = ettAccountAnswer.Find_ByQuestionID_AccountID(_questionID, _accountID);
                if (accAnswer != null)
                    rblAnswer.SelectedValue = accAnswer.ANSID.ToString();
            }
        }
        protected void btSubmit_Click(object sender, EventArgs e)
        {
            Models.Entities.AccountAnswer ettAccountAnswer = new Models.Entities.AccountAnswer();
            ettAccountAnswer.Delete_ByQuestionID_AccountID(_questionID, _accountID);
            int answerID = Convert.ToInt32(rblAnswer.SelectedValue);
            ettAccountAnswer.Insert(_accountID, answerID);

            Models.Entities.Question ettQuestion = new Models.Entities.Question();
            Models.Question question = ettQuestion.Find(_questionID);

            Response.Redirect("~/EMP_AccountAnswer/" + question.VOTID);
        }
    }
}