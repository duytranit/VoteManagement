using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VoteManagement.Partials.Department
{
    public partial class Form : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            bool status = (bool)chbStatus.Checked;
            Models.Entities.Department ettDepartment = new Models.Entities.Department();

            if (lblID.Text.Equals(""))
            {
                ettDepartment.Insert(name, status);
            }
            else
            {
                int departmentID = Convert.ToInt32(lblID.Text);
                ettDepartment.Update(departmentID, name, status);
            }
            Response.Redirect("~/Department");
        }
    }
}