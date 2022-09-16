using Customer.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Core.Entities
{
    public class CustomerType:AuditedEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Customer>  Customers { get; set; }
    }
}
