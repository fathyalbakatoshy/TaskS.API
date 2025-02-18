using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace TaskAPI.Middleware
{
    /// <summary>
    /// Middleware for centralized exception handling and logging.
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async ValueTask InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async ValueTask HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorDetails = new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal server error."
            };

            return await context.Response.WriteAsync(JsonSerializer.Serialize(errorDetails));
        }
    }

    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
