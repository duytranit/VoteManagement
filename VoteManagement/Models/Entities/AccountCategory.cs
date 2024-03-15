using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.UI;

namespace VoteManagement.Models.Entities
{
    public class AccountCategory
    {
        public AccountCategory() { }
        public IEnumerable<Models.AccountCategory> AccountCategories
        {
            get
            {
                Models.VoteManagementEntities db = new Models.VoteManagementEntities();
                return db.AccountCategories;
            }
        }
        public Models.AccountCategory Find(int _categoryID)
        {
            return this.AccountCategories.FirstOrDefault(x => x.ID == _categoryID);
        }
        public void Load_AccountCategories_RadComboBox(RadComboBox _cbb)
        {
            _cbb.DataSource = this.AccountCategories.ToList();
            _cbb.DataValueField = "ID";
            _cbb.DataTextField = "Name";
            _cbb.DataBind();
        }
    }
}