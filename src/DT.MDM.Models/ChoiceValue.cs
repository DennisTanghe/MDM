using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.MDM.Models
{
    public class ChoiceValue : BaseModel
    {
        public string Value { get; set; }

        public List<ChoiceField> ChoiceFields { get; set; }
    }
}
