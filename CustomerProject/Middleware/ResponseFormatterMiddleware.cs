using Customer.Application.Shared.Common.Dtos;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerProject.Middleware
{
    public class ResponseFormatterMiddleware
    {
        ResponseOutputDto _responseOutputDto = new ResponseOutputDto();
        private readonly RequestDelegate _next;

        public ResponseFormatterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);

            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
            {
                await context.Response.WriteAsync(
                    JsonConvert.SerializeObject(_responseOutputDto.Status401Unauthorized()));//new ResponseOutputDto ResponseModel("some-message")));
            }
        }
    }
}
