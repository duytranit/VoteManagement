using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VoteManagement.Partials.Vote
{
    public partial class Form : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            int departmentID = System.Convert.ToInt32(cbbDepartment.SelectedValue.ToString());
            string name = txtName.Text;
            string description = txtDescription.Text;
            DateTime date = System.Convert.ToDateTime(dpkDate.SelectedDate);
            bool status = (bool)chbStatus.Checked;

            Models.Entities.Vote ettVote = new Models.Entities.Vote();

            if (lblID.Text.Equals(""))
            {
                ettVote.Insert(name, description, date, status, departmentID);
            }
            else
            {
                int voteID = Convert.ToInt32(lblID.Text);
                ettVote.Update(voteID, name, description, date, status, departmentID);
            }
            Response.Redirect("~/Vote");
        }
    }
}