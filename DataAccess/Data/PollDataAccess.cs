using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccess.Data
{
    public class PollDataAccess
    {
        public string Create(Poll model)
        {
            using (var db = new PollDBContext())
            {
                model.Id = Guid.NewGuid().ToString();
                db.Polls.Add(model);
                db.SaveChanges();
                return model.Id;
            }
        }
        public Poll Get(string id)
        {
            using (var db = new PollDBContext())
            {
                return db.Polls.Find(id);
            }
        }
        public List<Poll> GetByCreator(string creatorId)
        {
            using (var db = new PollDBContext())
            {
                return db.Polls.Where(x => x.UserId == creatorId).ToList();
            }
        }
        public List<Poll> GetPublicPolls()
        {
            using (var db = new PollDBContext())
            {
                return db.Polls.Where(x => x.IsPublished == true).ToList();
            }
        }
        public Poll GetById(string id)
        {
            using (var db = new PollDBContext())
            {
                return db.Polls.Find(id);
            }
        }
        public Poll GetPublicPoll(string publicId)
        {
            using (var db = new PollDBContext())
            {
                return db.Polls.Where(x => x.PublicId == publicId).FirstOrDefault();
            }
        }
        public string Update(Poll model)
        {
            using (var db = new PollDBContext())
            {
                var target = db.Polls.Find(model.Id);
                if (target != null)
                {
                    db.Entry(target).CurrentValues.SetValues(model);
                    db.SaveChanges();
                    return model.Id;
                }
                return null;
            }
        }
        public void Delete(string pollId)
        {
            using (var db = new PollDBContext())
            {
                var target = db.Polls.Find(pollId);
                if (target != null)
                {
                    db.Polls.Remove(target);
                    db.SaveChanges();

                    var questions = db.Questions.Where(x => x.PollId == pollId).ToList();
                    if (questions != null)
                    {
                        foreach (var q in questions)
                        {
                            db.Questions.Remove(q);
                            db.SaveChanges();

                            var options = db.Options.Where(x => x.QuestionId == q.QuestionId).ToList();
                            if (options != null)
                            {
                                foreach (var o in options)
                                {
                                    db.Options.Remove(o);
                                    db.SaveChanges();

                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
