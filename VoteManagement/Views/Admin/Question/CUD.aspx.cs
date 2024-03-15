using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VoteManagement.Views.Admin.Question
{
    public partial class CUD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.RouteData.Values["questionID"] != null)
                try
                {
                    int questionID = Convert.ToInt32(this.Page.RouteData.Values["questionID"]);
                    Models.Entities.Question ettQuestion = new Models.Entities.Question();
                    Models.Question question = ettQuestion.Find(questionID);
                    if (question != null)
                    {
                        RGAnswer.QuestionID = questionID;
                        lblVOTName.Text = question.Vote.Name;
                        lblQUEContent.Text = question.Content;
                    }                        
                    else
                        Response.Redirect("~/");
                }catch
                {
                    Response.Redirect("~/");
                }
            else
                Response.Redirect("~/");
        }
    }
}