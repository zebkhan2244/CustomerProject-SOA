using Customer.Application.Shared.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Shared.Dtos.Customer
{
    public class CustomerInputDto: AuditedDto
    {
     
        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }
        public int CustomerTypeId { get; set; }
    }
}
