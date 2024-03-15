using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VoteManagement.Partials.Account
{
    public partial class Form : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string name = txtName.Text;
            int categoryID = Convert.ToInt32(cbbCategory.SelectedValue);
            int departmentID = Convert.ToInt32(cbbDepartment.SelectedValue);
            bool status = (bool)chbStatus.Checked;

            Models.Entities.Account ettAccount = new Models.Entities.Account();

            if (lblID.Text.Equals(""))
            {
                ettAccount.Insert(username, password, name, categoryID, departmentID, status);
            }
            else
            {
                int accountID = Convert.ToInt32(lblID.Text);
                ettAccount.Update(accountID, username, password, name, categoryID, departmentID, status);
            }
            Response.Redirect("~/Account");
        }
    }
}