using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Context;

public partial class SelectedOption
{
    public int SelectedOptionId { get; set; }

    public string AnswerId { get; set; } = null!;

    public string OptionContent { get; set; } = null!;

}
