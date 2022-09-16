using Customer.Application.Shared.Common.Dtos;
using Customer.Application.Shared.Dtos.CustomerType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Shared.Interfaces
{
    public interface ICustomerTypeAppService
    {
        Task<ResponseOutputDto> GetAll();

        Task<ResponseOutputDto> GetById(int id);

        Task<ResponseOutputDto> Create(CustomerTypeInputDto customerInputDto);

        Task<ResponseOutputDto> Update(CustomerTypeInputDto customerInputDto);

        Task<ResponseOutputDto> Delete(int id);
    }
}
