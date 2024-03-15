using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoteManagement.Helpers
{
    public class Page
    {
        public Page() { }
        public void AlertMessage(System.Web.UI.Page _page, string _message)
        {
            _page.ClientScript.RegisterStartupScript(_page.GetType(), "Script", "<script>" +
                    "alert('" + _message + "');"
                    + "</script>");
        }
    }
}