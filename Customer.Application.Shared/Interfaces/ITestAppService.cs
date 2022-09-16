using Customer.Application.Shared.Common.Dtos;
using Customer.Application.Shared.Dtos.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Shared.Interfaces
{
    public interface ITestAppService
    {
        Task<ResponseOutputDto> GetAll();

        Task<ResponseOutputDto> GetById(int id);


        Task<ResponseOutputDto> Create(TestInputDto customerInputDto);

        Task<ResponseOutputDto> Update(TestInputDto customerInputDto);

        Task<ResponseOutputDto> Delete(int id);
    }
}
