using System;
using System.Collections.Generic;

namespace DataAccess.Context;

public partial class UsersVote
{
    public string UserId { get; set; } = null!;

    public int SelectedOptionId { get; set; }

    public string PublicId { get; set; } = null!;
    public string? AnswerId { get; set; }
}
