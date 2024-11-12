
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Domain.Exceptions;

namespace SchoolManagement.API.Middlewares
{
    public class GlobalCustomExceptionHandlerMiddleware : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            int status = exception switch
            {
                ArgumentException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            httpContext.Response.StatusCode = status;

            var problemDetails = new ProblemDetails
            {
                Type = exception.GetType().Name,
                Title = exception.Message,
                Status = status,
                Detail = exception.StackTrace
            };

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
