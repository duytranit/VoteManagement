using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VoteManagement.Views.Employee.Question
{
    public partial class CUD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.RouteData.Values["questionID"] != null)
                try
                {
                    int questionID = Convert.ToInt32(this.Page.RouteData.Values["questionID"]);
                    formAccountAnswer.QuestionID = questionID;
                    formAccountAnswer.AccountID = 2;
                }
                catch
                {
                    Response.Redirect("~/");
                }
            else
                Response.Redirect("~/");
        }
    }
}