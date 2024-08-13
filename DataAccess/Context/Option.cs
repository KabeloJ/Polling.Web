using System;
using System.Collections.Generic;

namespace DataAccess.Context;

public partial class Option
{
    public int OptionId { get; set; }

    public string QuestionId { get; set; } = null!;

    public string OptionContent { get; set; } = null!;
}
