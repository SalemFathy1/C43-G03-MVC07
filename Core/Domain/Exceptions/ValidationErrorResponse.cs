using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ValidationErrorResponse // BadRequest
    {
        public int StatusCode { get; set; } = (int) HttpStatusCode.BadRequest;
        public string ErrorMessage { get; set; } = "Validation Failed";

        public IEnumerable<ValidationError> ValidationErrors { get; set; } = [];
    }
}
