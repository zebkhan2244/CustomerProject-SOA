using Customer.Application.Shared.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Shared.Dtos.CustomerType
{
   public  class CustomerTypeOutputDto: AuditedDto
    {
        public string Name { get; set; }
    }
}
