using Customer.Application.Shared.Common.Dtos;
using Customer.Application.Shared.Dtos.Test;
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
    public class TestController : ControllerBase
    {
        private readonly ITestAppService _testAppService;
        public TestController(ITestAppService testAppService)
        {
            _testAppService = testAppService;

        }

        [Route("GetAll")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _testAppService.GetAll();
            return Ok(response);
        }
        [Route("GetById/{id}")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _testAppService.GetById(id);
            return Ok(response);
        }
        [Route("Add")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Add(TestInputDto testInputDto)
        {
            var response = await _testAppService.Create(testInputDto);
            return Ok(response);
        }
        [Route("Update")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Update(TestInputDto testInputDto)
        {
            var response = await _testAppService.Update(testInputDto);
            return Ok(response);
        }
        [Route("Delete")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _testAppService.Delete(id);
            return Ok(response);
        }
    }
}
