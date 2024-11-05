using Microsoft.IdentityModel.Logging;
using Newtonsoft.Json;
using SchoolManagement.Domain.Exceptions;
using SchoolManagement.Domain.Models.Base;
using System.Net;

namespace SchoolManagement.API.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;
        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context)
        {

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        public async Task HandleExceptionAsync (HttpContext context, Exception ex)
        {
            var responseData = new ApiResponseModel
            {
                Message = ex.Message,
                ErrorDetails = null,
            };

            if (ex is NotFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                responseData.StatusCode = HttpStatusCode.NotFound;
            }
            else
            {
                _logger.LogError(ex, "An unhandled exception occurred.");
                responseData.ErrorDetails = ex.StackTrace;
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                responseData.StatusCode = HttpStatusCode.InternalServerError;
            }

            var responseJson = JsonConvert.SerializeObject(responseData);
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(responseJson);
        }
    }
}
