using AutoMapper;
using Customer.Application.Shared.Dtos.Customer;
using Customer.Application.Shared.Dtos.CustomerType;
using Customer.Application.Shared.Dtos.Test;
using Customer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Mapper
{
   public class InputDtoToEntityMapper:Profile
    {
        public InputDtoToEntityMapper()
        {
            CreateMap<TestInputDto, Test>();
            CreateMap<CustomerTypeInputDto, CustomerType>();
            CreateMap<CustomerInputDto, Customer.Core.Entities.Customer>();

        }
    }
}
