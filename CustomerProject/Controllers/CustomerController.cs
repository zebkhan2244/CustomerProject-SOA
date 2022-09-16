using Customer.Application.Shared.Common.Dtos;
using Customer.Application.Shared.Dtos.Customer;
using Customer.Application.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerAppService _customerAppService;
        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;

        }

        [Route("GetAll")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _customerAppService.GetAll();
            return Ok(response);
        }
        [Route("GetById/{id}")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _customerAppService.GetById(id);
            return Ok(response);
        }
        [Route("Add")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CustomerInputDto customerInputDto)
        {
            customerInputDto.Id = 0;
            customerInputDto.CreatedBy = 1;
            customerInputDto.CreatedDateTime = DateTime.Now;
            customerInputDto.IsDeleted = false;
            var response = await _customerAppService.Create(customerInputDto);
            return Ok(response);
        }
        [Route("Update")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Update(CustomerInputDto customerInputDto)
        {
            customerInputDto.UpdatedBy = 1;
            customerInputDto.UpdatedDateTime = DateTime.Now;
            customerInputDto.IsDeleted = false;
            var response = await _customerAppService.Update(customerInputDto);
            return Ok(response);
        }
        [Route("Delete")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _customerAppService.Delete(id);
            return Ok(response);
        }
    }
}
