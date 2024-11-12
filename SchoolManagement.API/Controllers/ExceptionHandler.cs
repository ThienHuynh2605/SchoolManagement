using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SchoolManagement.Domain.Exceptions;
using SchoolManagement.Domain.Models.Base;
using System.Diagnostics;
using System.Net;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ExceptionHandler : ControllerBase
    {
        private readonly ILogger<ExceptionHandler> _logger;
        public ExceptionHandler(ILogger<ExceptionHandler> logger)
        {
            _logger = logger;
        }

        [Route("/error-development")]
        public IActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;
            _logger.LogError(exceptionHandlerFeature.Error, exceptionHandlerFeature.Error.Message);

            var status = HttpContext.Response.StatusCode;

            if (exceptionHandlerFeature.Error is NotFoundException)
            {
                //HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                status = (int)HttpStatusCode.NotFound;
            }

            if (exceptionHandlerFeature.Error is ArgumentException)
            {
                status = 400;
            }

            //return Problem(
            //    detail: exceptionHandlerFeature.Error.StackTrace,
            //    title: exceptionHandlerFeature.Error.Message,
            //    statusCode: status);
            var problemDetails = new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc9110#section-15.5.5",
                Status = status,
                Title = exceptionHandlerFeature.Error.Message,
                Detail = exceptionHandlerFeature.Error.StackTrace,
            };

            return new ObjectResult(problemDetails)
            {
                //StatusCode = HttpContext.Response.StatusCode
                StatusCode = StatusCodes.Status200OK
            };
        }

        [Route("/error")]
        public IActionResult HandleError()
        {
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;
            _logger.LogError(exceptionHandlerFeature.Error, exceptionHandlerFeature.Error.Message);

            return Problem();
        }
    }
}
