using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Answer
{
    public class AnswerModel
    {
        public string AnswerId { get; set; } = null!;

        public string QuestionId { get; set; } = null!;

        public string PollPublicId { get; set; } = null!;

        public int SequenceNo { get; set; }

        public string QuestionContent { get; set; } = null!;
        public List<SelectedOptionModel> SelectedOptionsModel { get; set; } = null!;
    }
}
