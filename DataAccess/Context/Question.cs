using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace DataAccess.Context;

public partial class Question
{
    public string QuestionId { get; set; } = null!;

    public int SequenceNo { get; set; }

    public string PollId { get; set; } = null!;

    public string QuestionContent { get; set; } = null!;
    public List<Option> Options { get; set; }
}
