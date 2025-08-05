using AutoMapper;
using Core.Option;
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
        private readonly IMapper _map;
        public OptionDataAccess(IMapper map)
        {
            _map = map;
        }
        public int Create(OptionModel model)
        {
            using (var db = new PollDBContext())
            {
                db.Options.Add(_map.Map<Option>(model));
                db.SaveChanges();
                return model.OptionId;
            }
        }
        public OptionModel Get(int optionId)
        {
            using (var db = new PollDBContext())
            {
                return _map.Map<OptionModel>(db.Options.Find(optionId));
            }
        }
        public List<OptionModel> GetByQuestion(string questionId)
        {
            using (var db = new PollDBContext())
            {
                return _map.Map<List<OptionModel>>(db.Options.Where(x => x.QuestionId == questionId).ToList());
            }
        }
        public int Update(OptionModel model)
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
