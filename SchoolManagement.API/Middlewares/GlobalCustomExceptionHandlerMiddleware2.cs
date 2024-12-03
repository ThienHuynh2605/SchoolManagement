using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Domain.Exceptions;
using System.Net;

namespace SchoolManagement.API.Middlewares
{
    public class GlobalCustomExceptionHandlerMiddleware2(IProblemDetailsService problemDetailsService) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var problemDetails = new ProblemDetails
            {
                Title = "An error occurred.",
                Detail = exception.Message
            };

            if (exception is NotFoundException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                problemDetails.Status = (int)HttpStatusCode.NotFound;
            }
            else if(exception is ArgumentException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                problemDetails.Status = (int)HttpStatusCode.BadRequest;
            }
            else if(exception is UnauthorizedAccessException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                problemDetails.Status = (int)HttpStatusCode.Unauthorized;
            }
            else
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                problemDetails.Status = (int)HttpStatusCode.InternalServerError;
                problemDetails.Detail = exception.StackTrace;
            }

            

            return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
            {
                Exception = exception,
                HttpContext = httpContext,
                ProblemDetails = problemDetails
            });
        }
    }
}
