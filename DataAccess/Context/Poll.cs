using System;
using System.Collections.Generic;

namespace DataAccess.Context;

public partial class Poll
{
    public string Id { get; set; } = null!;

    public string PollName { get; set; } = null!;

    public string? PollDescription { get; set; }

    public DateTime DateCreated { get; set; }

    public bool IsPublished { get; set; }

    public string? PublicId { get; set; }

    public string? UserId { get; set; }

    public DateTime? DatePublished { get; set; }
    public List<Question> Questions { get; set; }
}
