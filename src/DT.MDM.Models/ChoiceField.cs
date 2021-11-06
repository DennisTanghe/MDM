using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.MDM.Models
{
    public class ChoiceField : Field
    {
        public List<ChoiceValue> ChoiceValues { get; set; }
    }
}
