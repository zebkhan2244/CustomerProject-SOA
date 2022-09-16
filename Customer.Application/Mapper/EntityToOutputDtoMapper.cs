using AutoMapper;
using Customer.Core.Entities;
using Customer.Application.Shared.Dtos.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer.Application.Shared.Dtos.Customer;
using Customer.Application.Shared.Dtos.CustomerType;

namespace Customer.Application.Mapper
{
   public class EntityToOutputDtoMapper : Profile
    {
        public EntityToOutputDtoMapper()
        {
            CreateMap<Test, TestOutputDto>();
            CreateMap<Customer.Core.Entities.CustomerType, CustomerTypeOutputDto>();
            CreateMap<Customer.Core.Entities.Customer, CustomerOutputDto>();

        }
    }
}
