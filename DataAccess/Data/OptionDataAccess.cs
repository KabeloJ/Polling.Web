using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class OptionDataAccess
    {
        public int Create(Option model)
        {
            using (var db = new PollDBContext())
            {
                db.Options.Add(model);
                db.SaveChanges();
                return model.OptionId;
            }
        }
        public Option Get(int optionId)
        {
            using (var db = new PollDBContext())
            {
                return db.Options.Find(optionId);
            }
        }
        public List<Option> GetByQuestion(string questionId)
        {
            using (var db = new PollDBContext())
            {
                return db.Options.Where(x => x.QuestionId == questionId).ToList();
            }
        }
        public int Update(Option model)
        {
            using (var db = new PollDBContext())
            {
                var target = db.Options.Find(model.OptionId);
                if (target != null)
                {
                    db.Entry(target).CurrentValues.SetValues(model);
                    db.SaveChanges();
                    return model.OptionId;
                }
                return 0;
            }
        }
        public void DeleteOptions(string questionId)
        {
            using (var db = new PollDBContext())
            {
                var targets = db.Options.Where(x => x.QuestionId == questionId).ToList();
                if (targets != null)
                {
                    foreach (var item in targets)
                    {
                        db.Options.Remove(item);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
