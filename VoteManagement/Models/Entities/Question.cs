using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace VoteManagement.Models.Entities
{
    public class Question
    {
        public Question() { }
        private IEnumerable<Models.Question> Questions { get
            {
                Models.VoteManagementEntities db = new VoteManagementEntities();
                return db.Questions;
            } }
        private IEnumerable<object> ConvertObject(IEnumerable<Models.Question> _questions)
        {
            return _questions.AsEnumerable().Select(que => new
            {
                ID = que.ID,
                Content = que.Content,
                VOTID = que.VOTID,
                VOTName = que.Vote.Name
            });
        }
        public void Insert(int _voteID, string _content)
        {
            Models.VoteManagementEntities db = new VoteManagementEntities();
            Models.Question question = new Models.Question();
            question.VOTID = _voteID;
            question.Content = _content;
            db.Questions.Add(question);
            db.SaveChanges();
            db.Dispose();
        }
        public void Update(int _questionID, int _voteID, string _content)
        {
            Models.VoteManagementEntities db = new VoteManagementEntities();
            Models.Question question = db.Questions.FirstOrDefault(x => x.ID == _questionID);
            question.VOTID = _voteID;
            question.Content = _content;
            db.SaveChanges();
            db.Dispose();
        }
        public void Delete(int _questionID)
        {
            Models.VoteManagementEntities db = new VoteManagementEntities();
            Models.Question question = db.Questions.FirstOrDefault(x => x.ID == _questionID);
            db.Questions.Remove(question);
            db.SaveChanges();
            db.Dispose();
        }
        public Models.Question Find(int _questionID)
        {
            Models.VoteManagementEntities db = new VoteManagementEntities();
            return db.Questions.FirstOrDefault(x => x.ID == _questionID);
        }
        private IEnumerable<Models.Question> Find_ByVoteID(int _voteID)
        {
            return this.Questions.Where(que => que.VOTID == _voteID);
        }
        public IEnumerable<object> Find_ByVoteID(int _voteID, int _accountID)
        {
            Models.Entities.Answer ettAnswer = new Answer();
            Models.VoteManagementEntities db = new VoteManagementEntities();
            return db.Questions.Where(x => x.VOTID == _voteID && x.Answers.Count() > 0).Select(x => new 
            { 
                ID = x.ID,
                Content = x.Content,
                ANSContent = x.Answers.FirstOrDefault(ans => ans.AccounAnswers.Where(anc => anc.ACCID == _accountID).Count() > 0).Content,
                ANSID = x.Answers.FirstOrDefault(ans => ans.AccounAnswers.Where(anc => anc.ACCID == _accountID).Count() > 0).ID,
                SelectCommandAnswer = "SELECT * FROM [ANSWER] WHERE [QUEID] = " + x.ID
            });
        }
        public void Load_Question_ByVote_RadGrid(RadGrid _rg, int _voteID, int _accountID)
        {
            _rg.DataSource = this.Find_ByVoteID(_voteID, _accountID).ToList();
        }
        public void Load_QuestionOfVote_ToRadGrid(RadGrid _rg, int _voteID)
        {
            _rg.DataSource = this.ConvertObject(this.Find_ByVoteID(_voteID)).ToList();
        }
    }
}