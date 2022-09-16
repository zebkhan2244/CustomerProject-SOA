using AutoMapper;
using Customer.Application.Shared.Common.Dtos;
using Customer.Application.Shared.Common.Interfaces;
using Customer.Application.Shared.Dtos.Test;
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
    public class TestAppservice : ITestAppService
    {
        IRepository<Test> _repository;
        private readonly IMapper _mapper;
        ResponseOutputDto _responseOutputDto = new ResponseOutputDto();
        public TestAppservice(IRepository<Test> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;


        }
        public async Task<ResponseOutputDto> Create(TestInputDto testInputDto)
        {
            var entity = _mapper.Map<Customer.Core.Entities.Test>(testInputDto);
            var entityId = await _repository.Create(entity);
            if (entityId > 0)
            {
                testInputDto.Id = entity.Id;
                _responseOutputDto.Success<TestInputDto>(testInputDto);
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

            var testOutputDto = _mapper.Map<List<TestOutputDto>>(entities);

            _responseOutputDto.Success<IEnumerable<TestOutputDto>>(testOutputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> GetById(int id)
        {
            var entity = await _repository.GetById(id);
            var testInputDto = _mapper.Map<TestInputDto>(entity);

            _responseOutputDto.Success<TestInputDto>(testInputDto);
            return _responseOutputDto;
        }

        public async Task<ResponseOutputDto> Update(TestInputDto testInputDto)
        {
            var entity = _mapper.Map<Customer.Core.Entities.Test>(testInputDto);
            var res = await _repository.Update(entity);
            if (res > 0)
            {
                _responseOutputDto.Success<TestInputDto>(testInputDto);
            }
            else
            {
                _responseOutputDto.Error();
            }
            return _responseOutputDto;
        }
    }
}
