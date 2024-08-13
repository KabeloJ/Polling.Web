using DataAccess.Context;
using DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class PollVoteModel
    {
        public PollVoteModel(string publicId)
        {
            var pollData = new PollDataAccess();
            PublicId = publicId;
            poll = pollData.GetPublicPoll(PublicId);

            var _answers = new AnswerDataAccess();
            Answers = _answers.GetByPoll(poll.PublicId);
        }

        public Poll poll { get; set; }
        public List<Answer> Answers { get; set; }
        public string PublicId { get; set; }
        public string UserId { get; set; }

    }
}
