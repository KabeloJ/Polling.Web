using System;
using System.Collections.Generic;

namespace DataAccess.Context;

public partial class PublicPoll
{
    public string PollId { get; set; } = null!;

    public string PublicId { get; set; } = null!;

    public DateTime DatePublished { get; set; }

    public bool IsActive { get; set; }
}
