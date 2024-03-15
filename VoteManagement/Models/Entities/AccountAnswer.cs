using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoteManagement.Models.Entities
{
    public class AccountAnswer
    {
        public AccountAnswer() { }
        public void Insert(int _accountID, int _answerID)
        {
            Models.VoteManagementEntities db = new Models.VoteManagementEntities();
            Models.AccounAnswer accAnswer = new AccounAnswer();
            accAnswer.ACCID = _accountID;
            accAnswer.ANSID = _answerID;
            db.AccounAnswers.Add(accAnswer);
            db.SaveChanges();
            db.Dispose();
        }
        public void Delete_ByQuestionID_AccountID(int _questionID, int _accountID)
        {
            Models.VoteManagementEntities db = new VoteManagementEntities();
            Models.AccounAnswer accounAnswer = db.AccounAnswers.FirstOrDefault(x => x.Answer.QUEID == _questionID && x.ACCID == _accountID);
            if (accounAnswer != null)
            {
                db.AccounAnswers.Remove(accounAnswer);
                db.SaveChanges();
            }            
            db.Dispose ();
        }
        public Models.AccounAnswer Find_ByQuestionID_AccountID(int _questionID, int _accountID)
        {
            Models.VoteManagementEntities db = new VoteManagementEntities();
            return db.AccounAnswers.FirstOrDefault(x => x.Answer.QUEID == _questionID && x.ACCID == _accountID);
        }
    }
}