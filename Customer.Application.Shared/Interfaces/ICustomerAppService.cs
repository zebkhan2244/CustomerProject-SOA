using Customer.Application.Shared.Common.Dtos;
using Customer.Application.Shared.Dtos.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Shared.Interfaces
{
    public interface ICustomerAppService
    {
        Task<ResponseOutputDto> GetAll();

        Task<ResponseOutputDto> GetById(int id);

        Task<ResponseOutputDto> Create(CustomerInputDto customerInputDto);

        Task<ResponseOutputDto> Update(CustomerInputDto customerInputDto);

        Task<ResponseOutputDto> Delete(int id);
    }
}
