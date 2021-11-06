using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.MDM.Models
{
    public class Entity : BaseModel
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public List<Field> Attributes { get; set; }
    }
}
