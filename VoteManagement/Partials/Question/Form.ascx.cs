using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VoteManagement.Partials.Question
{
    public partial class Form : System.Web.UI.UserControl
    {
        private int _voteID;
        protected void Page_Load(object sender, EventArgs e)
        {
            _voteID = Convert.ToInt32(this.Page.RouteData.Values["voteID"]);
            Models.Entities.Vote ettVote = new Models.Entities.Vote();
            Models.Vote vote = ettVote.Find(_voteID);
            lblVOTName.Text = vote.Name;
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string content = txtContent.Text;
            Models.Entities.Question ettQuestion = new Models.Entities.Question();
            if (lblID.Text.Equals(""))
                ettQuestion.Insert(_voteID, content);
            else
            {
                int questionID = Convert.ToInt32(lblID.Text);
                ettQuestion.Update(questionID, _voteID, content);
            }
        }
    }
}