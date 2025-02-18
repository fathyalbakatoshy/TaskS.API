//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Text.Json;
//using System.Threading.Tasks;

//namespace Task.API.Middlewares
//{
//    public class ErrorHandlingMiddleware
//    {
//        private readonly RequestDelegate _next;
//        private readonly ILogger<ErrorHandlingMiddleware> _logger;

//        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
//        {
//            _next = next;
//            _logger = logger;
//        }

//        public async Task Invoke(HttpContext context)
//        {
//            try
//            {
//                await _next(context);
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "An unhandled exception has occurred");
//                context.Response.StatusCode = 500;
//                context.Response.ContentType = "application/json";

//                var result = JsonSerializer.Serialize(new { error = ex.Message });
//                await context.Response.WriteAsync(result);
//            }
//        }
//    }
//}
