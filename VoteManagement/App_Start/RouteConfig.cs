using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace VoteManagement
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.EnableFriendlyUrls();

            routes.MapPageRoute("Default", "", "~/Views/NonLogin/Login.aspx");
            routes.MapPageRoute("Vote", "Vote", "~/Views/Admin/Vote/Index.aspx");
            routes.MapPageRoute("Vote_Detail", "Vote/{voteID}", "~/Views/Admin/Vote/CUD.aspx");
            routes.MapPageRoute("Question_Detail", "Question/{questionID}", "~/Views/Admin/Question/CUD.aspx");
            routes.MapPageRoute("Department", "Department", "~/Views/Admin/Department/Index.aspx");
            routes.MapPageRoute("Work", "Work", "~/Views/Admin/Work/Index.aspx");
            routes.MapPageRoute("Account", "Account", "~/Views/Admin/Account/Index.aspx");

            //Employee
            routes.MapPageRoute("Emp_Vote", "EMP_Vote", "~/Views/Employee/Vote/Index.aspx");
            routes.MapPageRoute("Emp_AccountAnswer", "EMP_AccountAnswer/{voteID}", "~/Views/Employee/Question/Index.aspx");
        }
    }
}
