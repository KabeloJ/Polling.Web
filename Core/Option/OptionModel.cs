using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Option
{
    public class OptionModel
    {
        public int OptionId { get; set; }

        public string QuestionId { get; set; } = null!;

        public string OptionContent { get; set; } = null!;
    }
}
