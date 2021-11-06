using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.MDM.Models
{
    public class Field : BaseModel
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public FieldType DataType { get; set; }

        public string DefaultValue { get; set; }

        public List<Entity> Entities { get; set; }
    }
}
