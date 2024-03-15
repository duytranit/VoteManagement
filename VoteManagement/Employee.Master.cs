using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.Device.Detection;
using Telerik.Web.UI;

namespace VoteManagement
{
    public partial class Employee : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            DeviceScreenDimensions screenDimensions = Detector.GetScreenDimensions(Request.UserAgent);
            LoadMobile(screenDimensions);
        }

        private void LoadMobile(DeviceScreenDimensions screenDimensions)
        {

        }

        protected void SignOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }
    }
}