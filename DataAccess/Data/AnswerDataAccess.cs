using Azure.Core;
using Core.Answer;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Core.Answer.DataAccess;

namespace DataAccess.Data
{
    public class AnswerDataAccess: IAnswerDataAccess
    {
        public List<AnswerModel> GetByPoll(string pollId)
        {
            using (var db = new PollDBContext())
            {
                var data = db.Answers.Where(x => x.PollPublicId == pollId).Include(x=>x.SelectedOptions).ToList();
                return MapToModel(data);
            }
        }
        List<AnswerModel> MapToModel(List<Answer> answers)
        {
            List<AnswerModel> model = new List<AnswerModel>();
            foreach (var item in answers)
            {
                model.Add(MapToModel(item));
            }
            return model;
        }
        AnswerModel MapToModel(Answer a)
        {
            AnswerModel model = new AnswerModel()
            {
               AnswerId = a.AnswerId,
               PollPublicId = a.PollPublicId,
               QuestionContent = a.QuestionContent,
               QuestionId = a.QuestionId,
               SequenceNo = a.SequenceNo
            };
            return model;
        }
    }
}
