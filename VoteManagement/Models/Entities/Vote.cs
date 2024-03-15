using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace VoteManagement.Models.Entities
{
    public class Vote
    {
        public Vote() { }
        public IEnumerable<object> Votes { 
            get { 
                Models.VoteManagementEntities db = new Models.VoteManagementEntities();
                return db.Votes.AsEnumerable().Select(x => new { 
                    ID = x.ID,
                    Name = x.Name,
                    Description = x.Description,
                    Date = x.Date,
                    Status = x.Status,
                    DPMID = x.DPTID,
                    DPMName = x.Department.Name
                });
            } 
        }
        public int MaxAnswerNumber(int _voteID)
        {
            int number = 0;
            Models.Vote vote = this.Find(_voteID);
            if (vote != null)
                foreach (Models.Question question in vote.Questions)
                    if (question.Answers.Count() > number)
                        number = question.Answers.Count();
            return number;
        }
        public void Insert(string _name, string _description, DateTime _date, bool _status, int _departmentID) 
        {
            Models.VoteManagementEntities db = new VoteManagementEntities();
            Models.Vote vote = new Models.Vote();
            vote.Name = _name;
            vote.Description = _description;
            vote.Date = _date;
            vote.Status = _status;
            vote.DPTID = _departmentID;
            db.Votes.Add(vote);
            db.SaveChanges();
            db.Dispose();
        }
        public void Update(int _id, string _name, string _description, DateTime _date, bool _status, int _departmentID)
        {
            Models.VoteManagementEntities entities = new VoteManagementEntities();
            Models.Vote vote = entities.Votes.FirstOrDefault(x => x.ID == _id);
            vote.Name = _name;
            vote.Description = _description;
            vote.Date = _date;
            vote.Status = _status;
            vote.DPTID= _departmentID;
            entities.SaveChanges();
            entities.Dispose();
        }
        public void Delete(int _id)
        {
            Models.VoteManagementEntities entities = new VoteManagementEntities();
            Models.Vote vote = entities.Votes.FirstOrDefault(x => x.ID == _id);
            entities.Votes.Remove(vote);
            entities.SaveChanges();
            entities.Dispose();
        }
        public Models.Vote Find(int _id)
        {
            Models.VoteManagementEntities db = new VoteManagementEntities();
            return db.Votes.FirstOrDefault(x => x.ID == _id);
        }
        public IEnumerable<Models.Vote> Find_ByAccountID(int _accountID)
        {
            Models.Entities.Account ettAccount = new Account();
            return ettAccount.Find(_accountID).Department.Votes;
        }
        public void Load_AllVote_RadGrid(Telerik.Web.UI.RadGrid grid)
        {
            grid.DataSource = this.Votes.ToList();
        }
        public void Load_Vote_OfAccount_RadGrid(Telerik.Web.UI.RadGrid _rg, int _accountID)
        {
            _rg.DataSource = this.Find_ByAccountID(_accountID).Where(vot => vot.Status == true).ToList();
        }
        public void Load_AllVote_RadComboBox(Telerik.Web.UI.RadComboBox _cbb)
        {
            _cbb.DataSource = this.Votes.ToList();
            _cbb.DataTextField = "Name";
            _cbb.DataValueField = "ID";
            _cbb.DataBind();
        }
    }
}