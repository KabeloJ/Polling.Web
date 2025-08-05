using Core.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Polls
{
    public class PollModel
    {
        public string Id { get; set; } = null!;

        public string PollName { get; set; } = null!;

        public string? PollDescription { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsPublished { get; set; }

        public string? PublicId { get; set; }

        public string? UserId { get; set; }

        public DateTime? DatePublished { get; set; }
        public List<QuestionModel> QuestionModel { get; set; }
    }
}
