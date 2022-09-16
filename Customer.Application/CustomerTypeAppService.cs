using AutoMapper;
using Customer.Application.Shared.Common.Dtos;
using Customer.Application.Shared.Common.Interfaces;
using Customer.Application.Shared.Dtos.CustomerType;
using Customer.Application.Shared.Interfaces;
using Customer.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application
{
    public class CustomerTypeAppService : ICustomerTypeAppService
    {
        IRepository<CustomerType> _repository;
        private readonly IMapper _mapper;
        ResponseOutputDto _responseOutputDto = new ResponseOutputDto();
        public CustomerTypeAppService(IRepository<CustomerType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;


        }
        public async Task<ResponseOutputDto> Create(CustomerTypeInputDto customerTypeInputDto)
        {
            var entity = _mapper.Map<Customer.Core.Entities.CustomerType>(customerTypeInputDto);
            var entityId = await _repository.Create(entity);
            if (entityId > 0)
            {
                customerTypeInputDto.Id = entity.Id;
                _responseOutputDto.Success<CustomerTypeInputDto>(customerTypeInputDto);
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
            var entities = await _repository.GetAll().ToListAsync();

            var customerTypeOutputDto = _mapper.Map<List<CustomerTypeOutputDto>>(entities);

            _responseOutputDto.Success<IEnumerable<CustomerTypeOutputDto>>(customerTypeOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> GetById(int id)
        {
            var entity = await _repository.GetById(id);
            var customerTypeOutputDto = _mapper.Map<CustomerTypeOutputDto>(entity);

            _responseOutputDto.Success<CustomerTypeOutputDto>(customerTypeOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> Update(CustomerTypeInputDto customerTypeInputDto)
        {
            var entity = _mapper.Map<Customer.Core.Entities.CustomerType>(customerTypeInputDto);
            var res = await _repository.Update(entity);
            if (res > 0)
            {
                _responseOutputDto.Success<CustomerTypeInputDto>(customerTypeInputDto);
            }
            else
            {
                _responseOutputDto.Error();
            }
            return _responseOutputDto;
        }
    }
}
