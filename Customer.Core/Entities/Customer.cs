using Customer.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Core.Entities
{
    public class Customer:AuditedEntity
    {
       [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(1024)]
        public string Description { get; set; }
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string State { get; set; }
        [Required]
        [MaxLength(50)]
        public string Zip { get; set; }
        public int CustomerTypeId { get; set; }
        public CustomerType CustomerType { get; set; }
    }
}
