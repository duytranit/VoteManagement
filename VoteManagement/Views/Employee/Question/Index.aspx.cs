using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VoteManagement.Views.Employee.Question
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.RouteData.Values["voteID"] != null)
                try
                {
                    partialRGQuestion.VoteID = Convert.ToInt32(this.Page.RouteData.Values["voteID"]);
                    int accountID = Convert.ToInt32(this.Session["accountID"]);
                    partialRGQuestion.AccountID = accountID;
                }
                catch
                {

                }
            else
                Response.Redirect("~/");

            
        }
    }
}