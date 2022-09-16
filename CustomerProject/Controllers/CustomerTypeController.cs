using Customer.Application.Shared.Common.Dtos;
using Customer.Application.Shared.Dtos.CustomerType;
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
    public class CustomerTypeController : ControllerBase
    {
        private readonly ICustomerTypeAppService _customertypeAppService;
        public CustomerTypeController(ICustomerTypeAppService customerTypeAppService)
        {
            _customertypeAppService = customerTypeAppService;

        }

        [Route("GetAll")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _customertypeAppService.GetAll();
            return Ok(response);
        }
        [Route("GetById/{id}")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _customertypeAppService.GetById(id);
            return Ok(response);
        }
        [Route("Add")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Add(CustomerTypeInputDto customerTypeInputDto)
        {
            var response = await _customertypeAppService.Create(customerTypeInputDto);
            return Ok(response);
        }
        [Route("Update")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Update(CustomerTypeInputDto customerTypeInputDto)
        {
            var response = await _customertypeAppService.Update(customerTypeInputDto);
            return Ok(response);
        }
        [Route("Delete")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _customertypeAppService.Delete(id);
            return Ok(response);
        }
    }
}
