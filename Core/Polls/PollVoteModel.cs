
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Answer;

namespace Core.Polls
{
    public class PollVoteModel
    {
        public PollVoteModel(string publicId)
        {
            var pollData = new PollDataAccess();
            PublicId = publicId;
            PollModel = pollData.GetPublicPoll(PublicId);

            var _answers = new AnswerDataAccess();
            AnswersModel = _answers.GetByPoll(PollModel.PublicId);
        }

        public PollModel PollModel { get; set; }
        public List<AnswerModel> AnswersModel { get; set; }
        public string PublicId { get; set; }
        public string UserId { get; set; }
        public int VotePer { get; set;}

    }
}
