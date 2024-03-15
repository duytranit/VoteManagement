using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Web.UI;

namespace VoteManagement
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cldDate.SelectedDate = DateTime.Now;
        }

        protected void btLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            Models.Entities.Account ettAccount = new Models.Entities.Account();
            Models.Account account = ettAccount.Login(username, password);
            if (account != null)
            {
                this.Session["accountID"] = account.ID;
                if (account.ACCID == 1)
                {
                    Response.Redirect("~/Vote");
                }
                else
                {
                    Response.Redirect("~/EMP_Vote");
                }
            }
            else
            {
                Helpers.Page hlpPage = new Helpers.Page();
                hlpPage.AlertMessage(this.Page, "Tài khoản không tồn tại");
            }
        }
    }
}