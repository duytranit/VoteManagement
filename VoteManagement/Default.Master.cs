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
    public partial class Default1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Session.Clear();
        }

        protected override void OnInit(EventArgs e)
        {
            DeviceScreenDimensions screenDimensions = Detector.GetScreenDimensions(Request.UserAgent);
            LoadMobile(screenDimensions);
        }

        private void LoadMobile(DeviceScreenDimensions screenDimensions)
        {
            // Desktop Browser Detected
            if (screenDimensions.Height == 0 && screenDimensions.Width == 0)
            {
                var mobileNavigation = FolderContent.FindControl("MobileNavigation");
                if (mobileNavigation != null)
                {
                    mobileNavigation.Visible = false;
                    nav.Value = "desktop";
                }
            }
            // Mobile Browser Detected
            else
            {
                this.form1.Attributes.Add("class", "mobile clear");
                var desktopNavigation = FolderContent.FindControl("FolderNavigationControl");
                if (desktopNavigation != null)
                {
                    desktopNavigation.Visible = false;
                    nav.Value = "mobile";
                }
            }
        }
    }
}