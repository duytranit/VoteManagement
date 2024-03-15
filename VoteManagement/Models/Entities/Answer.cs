using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.UI;

namespace VoteManagement.Models.Entities
{
    public class Answer
    {
        public Answer() { }
        public IEnumerable<Models.Answer> Answers_ByQuestionID(int _questionID)
        {
            Models.VoteManagementEntities db = new VoteManagementEntities();
            return db.Answers.Where(x => x.QUEID == _questionID);
        }
        public void Insert(int _questionID, string _content)
        {
            Models.VoteManagementEntities db = new VoteManagementEntities();
            Models.Answer answer = new Models.Answer();
            answer.QUEID = _questionID;
            answer.Content = _content;
            db.Answers.Add(answer);
            db.SaveChanges();
            db.Dispose();
        }
        public void Update(int _answerID, string _content)
        {
            Models.VoteManagementEntities db = new VoteManagementEntities();
            Models.Answer answer = db.Answers.FirstOrDefault(x => x.ID == _answerID);
            answer.Content = _content;
            db.SaveChanges();
            db.Dispose();
        }
        public void Delete(int _answerID)
        {
            Models.VoteManagementEntities db = new VoteManagementEntities();
            Models.Answer answer = db.Answers.FirstOrDefault(x => x.ID == _answerID);
            db.Answers.Remove(answer);
            db.SaveChanges();
            db.Dispose();
        }
        public void Load_AnswerByQuestionID_RadGrid(RadGrid _rg, int _questionID)
        {
            _rg.DataSource = this.Answers_ByQuestionID(_questionID).ToList();
        }
        public void Load_AnswerByQuestionID_RadGrid_WithoutDataBind(RadGrid _rg, int _questionID)
        {
            _rg.DataSource = this.Answers_ByQuestionID(_questionID).ToList();
        }
        public void Load_AnswerByQuestionID_RadRadioButtonList(RadRadioButtonList _rbl, int _questionID)
        {
            _rbl.DataSource = this.Answers_ByQuestionID(_questionID).ToList();
            _rbl.DataBindings.DataTextField = "Content";
            _rbl.DataBindings.DataValueField = "ID";
            _rbl.DataBind();
        }
    }
}