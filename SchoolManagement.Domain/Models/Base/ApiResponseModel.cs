using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Models.Base
{
    public class ApiResponseModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
        public string? ErrorDetails { get; set; }
    }
}
