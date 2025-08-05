using Core.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Question
{
    public class QuestionModel
    {
        public string QuestionId { get; set; } = null!;

        public int SequenceNo { get; set; }

        public string PollId { get; set; } = null!;

        public string QuestionContent { get; set; } = null!;
        public List<OptionModel> OptionModel { get; set; }
    }
}
