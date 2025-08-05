
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PollPublishService
    {
        private readonly QuestionDataAccess _questions;
        private readonly PollDataAccess _polls;
        public PollPublishService(QuestionDataAccess questions, PollDataAccess polls) 
        {
            _questions = questions;
            _polls = polls;
        }
        /// <summary>
        /// Returns Poll PublicId
        /// </summary>
        /// <param name="poll"></param>
        /// <returns></returns>
        public string Publish(PollModel poll)
        {
            if (poll != null)
            {
                poll.Questions = _questions.GetByPoll(poll.Id);

                poll.IsPublished = true;
                poll.PublicId = Guid.NewGuid().ToString();
                poll.DatePublished = DateTime.Now;
                _polls.Update(poll);

                bool created = CreatePublicPoll(poll);
                
                return poll.PublicId;
            }
            return null;
        }  
        public bool CheckUserVote(string userId, string publicId)
        {
            using(var db = new PollDBContext())
            {
                var data = db.UsersVotes.Where(x=>x.UserId == userId && x.PublicId == publicId).FirstOrDefault();
                if (data != null)
                {
                    return true;
                }
                return false;
            }
        }
        public bool CheckVoteForPoll(string publicId)
        {
            using(var db = new PollDBContext())
            {
                var data = db.UsersVotes.Where(x=>x.PublicId == publicId).FirstOrDefault();
                if (data != null)
                {
                    return true;
                }
                return false;
            }
        }
        public List<UsersVote> GetUserVotes(string userId, string publicId)
        {
            using (var db = new PollDBContext())
            {
                return db.UsersVotes.Where(x => x.UserId == userId && x.PublicId == publicId).ToList();
            }
        }
        public List<UsersVote> GetVotesForPoll(string publicId)
        {
            using (var db = new PollDBContext())
            {
                return db.UsersVotes.Where(x => x.PublicId == publicId).ToList();
            }
        }
        public bool SubmitVote(PollVoteModel model)
        {
            if (model != null && model.UserId != null && model.Answers != null)
            {
                foreach (var a in model.Answers)
                {
                    if (a != null)
                    {
                        foreach (var selected in a.SelectedOptions)
                        {
                            if (selected != null)
                            {
                                if (selected.IsSelected)
                                {
                                    SaveUserVote(new UsersVote()
                                    {
                                        SelectedOptionId = selected.SelectedOptionId,
                                        UserId = model.UserId,
                                        PublicId = model.PublicId,
                                        AnswerId = selected.AnswerId,
                                    });
                                }
                            }
                        }
                    }
                }
                return true;
            }
            return false;
        }
        void SaveUserVote(UsersVote vote)
        {
            if (vote != null)
            {
                try
                {
                    using (var db = new PollDBContext())
                    {
                        db.UsersVotes.Add(vote);
                        db.SaveChanges();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        bool CreatePublicPoll(Poll poll)
        {
            if (poll != null)
            {
                if (poll.Questions != null)
                {
                    foreach (var q in poll.Questions.OrderBy(x=>x.SequenceNo))
                    {
                        string answerId = CreatePollAnswers(q, poll.PublicId);
                        foreach (var op in q.Options.OrderBy(x=>x.OptionId))
                        {
                            CreateSelectedOptions(op, answerId);
                        }
                    }
                }

            }
            return true;
        }

        void CreateSelectedOptions(Option option, string answerId)
        {
            try
            {
                SelectedOption selectedOption = new SelectedOption()
                {
                    AnswerId = answerId,
                    OptionContent = option.OptionContent
                };
                using (var db = new PollDBContext())
                {
                    db.SelectedOptions.Add(selectedOption);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        string CreatePollAnswers(Question question, string publicId)
        {
            try
            {
                Answer answer = new Answer()
                {
                    AnswerId = Guid.NewGuid().ToString(),
                    PollPublicId = publicId,
                    QuestionId = question.QuestionId,
                    QuestionContent = question.QuestionContent,
                    //SequenceNo = question.SequenceNo
                };

                using (var db = new PollDBContext())
                {
                    db.Answers.Add(answer);
                    db.SaveChanges();
                    return answer.AnswerId;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

    }
}
