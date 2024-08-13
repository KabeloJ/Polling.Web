using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class QuestionDataAccess
    {
        public string Create(Question model)
        {
            using (var db = new PollDBContext())
            {
                model.QuestionId = Guid.NewGuid().ToString();
                model.SequenceNo = 0;
                db.Questions.Add(model);
                db.SaveChanges();
                return model.QuestionId;
            }
        }
        public Question Get(string questionId)
        {
            using (var db = new PollDBContext())
            {
                return db.Questions.Find(questionId);
            }
        }
        public List<Question> GetByPoll(string pollId)
        {
            using (var db = new PollDBContext())
            {
                return db.Questions.Where(x => x.PollId == pollId).Include(x => x.Options).ToList();
            }
        }
        public Question GetById(string questionId)
        {
            using (var db = new PollDBContext())
            {
                return db.Questions.Find(questionId);
            }
        }
        public string Update(Question model)
        {
            using (var db = new PollDBContext())
            {
                //model.SequenceNo = 0;
                var target = db.Questions.Find(model.QuestionId);
                if (target != null)
                {
                    db.Entry(target).CurrentValues.SetValues(model);
                    db.SaveChanges();
                    return model.QuestionId;
                }
                return null;
            }
        }
        public bool Delete(string questionId)
        {
            using (var db = new PollDBContext())
            {
                var target = db.Questions.Find(questionId);
                if (target != null)
                {
                    db.Questions.Remove(target);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
