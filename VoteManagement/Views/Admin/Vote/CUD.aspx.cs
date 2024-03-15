using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace VoteManagement.Views.Admin.Vote
{
    public partial class CUD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.RouteData.Values["voteID"] != null)
                try
                {
                    int voteID = Convert.ToInt32(this.Page.RouteData.Values["voteID"]);
                    Models.Entities.Vote ettVote = new Models.Entities.Vote();
                    Models.Vote vote = ettVote.Find(voteID);
                    if (vote != null)
                    {
                        RGQuestion.VoteID = voteID;
                        lblName.Text = vote.Name;
                    }
                    else
                        Response.Redirect("~/");
                    
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