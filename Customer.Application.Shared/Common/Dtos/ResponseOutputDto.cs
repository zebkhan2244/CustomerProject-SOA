using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Shared.Common.Dtos
{
    public class ResponseOutputDto
    {
        public bool IsSuccess { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public dynamic resultJSON { get; set; }

        public void Success<DtoType>(DtoType resultJSON) where DtoType : class
        {
            this.IsSuccess = true;
            this.Status = "Success";
            this.Message = "Success";
            this.resultJSON = resultJSON;
        }
        public void Error(string message = null)
        {
            this.IsSuccess = false;
            this.Status = "Error";
            this.Message = message == null ? "An error occured while processing your request" : message;
            this.resultJSON = "{}";
        }
        public ResponseOutputDto Status401Unauthorized()
        {
            ResponseOutputDto responseOutputDto = new ResponseOutputDto();
            responseOutputDto.IsSuccess = false;
            responseOutputDto.Status = "Unauthorized";
            responseOutputDto.Message = "You're Unauthorized either do not have valid token";
            responseOutputDto.resultJSON = "{}";
            return responseOutputDto;
        }
    }
}
