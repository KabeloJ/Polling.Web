using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class AnswerDataAccess
    {

        public List<Answer> GetByPoll(string pollId)
        {
            using (var db = new PollDBContext())
            {
                return db.Answers.Where(x => x.PollPublicId == pollId).Include(x=>x.SelectedOptions).ToList();
            }
        }
    }
}
