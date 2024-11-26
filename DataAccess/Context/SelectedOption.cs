using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Context;

public partial class SelectedOption
{
    public int SelectedOptionId { get; set; }

    public string AnswerId { get; set; } = null!;

    public string OptionContent { get; set; } = null!;
    [NotMapped]
    public bool IsSelected { get; set; }
    public int Calculate(int totalVotes, int selected)
    {
        if (selected > 0)
        {
            decimal val = Convert.ToDecimal(totalVotes) / selected;
            return Convert.ToInt32(val*100);
        }
        return 0;
    }

}
