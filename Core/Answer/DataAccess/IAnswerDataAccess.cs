using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Answer.DataAccess
{
    public interface IAnswerDataAccess 
    {
        List<AnswerModel> GetByPoll(string pollId);
    }
}
