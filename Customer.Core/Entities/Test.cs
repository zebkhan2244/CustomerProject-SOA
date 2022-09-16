using Customer.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Core.Entities
{
    public class Test:AuditedEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}
