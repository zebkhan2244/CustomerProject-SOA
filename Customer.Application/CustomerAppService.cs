using AutoMapper;
using Customer.Application.Shared.Common.Dtos;
using Customer.Application.Shared.Common.Interfaces;
using Customer.Application.Shared.Dtos.Customer;
using Customer.Application.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application
{
    public class CustomerAppService : ICustomerAppService
    {
        IRepository<Customer.Core.Entities.Customer> _repository;
        private readonly IMapper _mapper;
        ResponseOutputDto _responseOutputDto = new ResponseOutputDto();
        public CustomerAppService(IRepository<Customer.Core.Entities.Customer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        
        }
        public async Task<ResponseOutputDto> Create(CustomerInputDto customerInputDto)
        {
            var entity = _mapper.Map<Customer.Core.Entities.Customer>(customerInputDto);
            var entityId = await _repository.Create(entity);
            if (entityId > 0)
            {
                customerInputDto.Id = entity.Id;
                _responseOutputDto.Success<CustomerInputDto>(customerInputDto);
            }
            else
            {
                _responseOutputDto.Error();
            }
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> Delete(int id)
        {
            var entity = await _repository.GetById(id);
            entity.IsDeleted = true;
            var result = await _repository.Delete(entity);
            if (result > 0)
            {
                _responseOutputDto.Success<object>(entity);
            }
            else
            {
                _responseOutputDto.Error();
            }
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> GetAll()
        {
            var entities = await _repository.GetAll().Where(x=>x.IsDeleted==false).ToListAsync();

            var customerOutputDto = _mapper.Map<List<CustomerOutputDto>>(entities);

            _responseOutputDto.Success<IEnumerable<CustomerOutputDto>>(customerOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> GetById(int id)
        {
            var entity = await _repository.GetById(id);
            var customerOutputDto = _mapper.Map<CustomerOutputDto>(entity);

            _responseOutputDto.Success<CustomerOutputDto>(customerOutputDto);
            return _responseOutputDto;
        }
        public async Task<ResponseOutputDto> Update(CustomerInputDto customerInputDto)
        {
            var entity = _mapper.Map<Customer.Core.Entities.Customer>(customerInputDto);
            var res = await _repository.Update(entity);
            if (res > 0)
            {
                _responseOutputDto.Success<CustomerInputDto>(customerInputDto);
            }
            else
            {
                _responseOutputDto.Error();
            }
            return _responseOutputDto;
        }


      
    }
}
