using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.UI;

namespace VoteManagement.Models.Entities
{
    public class Account
    {
        public Account() { }
        public IEnumerable<object> Accounts
        {
            get
            {
                Models.VoteManagementEntities db = new VoteManagementEntities();
                return db.Accounts.AsEnumerable().Select(x => new 
                { 
                    ID = x.ID,
                    Username = x.UserName,
                    Name = x.Name,
                    AccountWithName = x.UserName + " / " + x.Name,
                    Status = x.Status,
                    ACCID = x.ACCID,
                    ACCName = x.AccountCategory.Name,
                    DPMID = x.DPMID,
                    DPMName = x.Department.Name
                });
            }
        }
        public Models.Account Login(string _username, string _password) 
        {
            Models.VoteManagementEntities db = new Models.VoteManagementEntities();
            return db.Accounts.FirstOrDefault(x => x.UserName.Equals(_username) && x.Password.Equals(_password) && x.Status == true && x.AccountCategory.Status == true);
        }
        public void Insert(string _username, string _password, string _name, int _categoryID, int _departmentID, bool _status)
        {
            Models.VoteManagementEntities db = new VoteManagementEntities();
            Models.Account account = new Models.Account();
            account.ACCID = _categoryID;
            account.DPMID = _departmentID;
            account.Name = _name;
            account.UserName = _username;
            account.Password = (_password.Equals("")) ? "123" : _password;
            account.Status = _status;
            db.Accounts.Add(account);
            db.SaveChanges();
            db.Dispose();
        }
        public void Update(int _accountID, string _username, string _password, string _name, int _categoryID, int _departmentID, bool _status)
        {
            Models.VoteManagementEntities db = new VoteManagementEntities();
            Models.Account account = db.Accounts.FirstOrDefault(x => x.ID == _accountID);
            account.ACCID = _categoryID;
            account.DPMID = _departmentID;
            account.Name = _name;
            account.UserName = _username;
            if (!_password.Equals(""))
                account.Password = _password;
            account.Status = _status;
            db.SaveChanges();
            db.Dispose();
        }
        public void Delete(int _accountID)
        {
            Models.VoteManagementEntities db = new VoteManagementEntities();
            Models.Account account = db.Accounts.FirstOrDefault(x => x.ID == _accountID);
            db.Accounts.Remove(account);
            db.SaveChanges() ;
            db.Dispose();
        }
        public Models.Account Find(int _accountID)
        {
            Models.VoteManagementEntities db = new VoteManagementEntities();
            return db.Accounts.FirstOrDefault(x => x.ID == _accountID);
        }
        public void Load_Account_RadComboBox(RadComboBox _cbb)
        {
            _cbb.DataSource = this.Accounts.ToList();
            _cbb.DataTextField = "AccountWithName";
            _cbb.DataValueField = "ID";
            _cbb.DataBind();
        }
        public void Load_Accounts_ToRadGrid(RadGrid _rg)
        {
            _rg.DataSource = this.Accounts.ToList();
        }
    }
}