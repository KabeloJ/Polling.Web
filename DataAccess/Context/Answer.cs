using System;
using System.Collections.Generic;

namespace DataAccess.Context;

public partial class Answer
{
    public string AnswerId { get; set; } = null!;

    public string QuestionId { get; set; } = null!;

    public string PollPublicId { get; set; } = null!;

    public int SequenceNo { get; set; }

    public string QuestionContent { get; set; } = null!;
    public List<SelectedOption> SelectedOptions { get; set; } = null!;
}
