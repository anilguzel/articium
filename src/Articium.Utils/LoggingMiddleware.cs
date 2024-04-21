using Microsoft.AspNetCore.Http;
using Serilog;

namespace Articium.Utils
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }
        

        public async Task Invoke(HttpContext context)
        {
            try
            {
                _logger.Information("Request received: {Method} {Path}", context.Request.Method, context.Request.Path);
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Exception occurred during request: {Method} {Path} {Exception}", context.Request.Method, context.Request.Path, ex.Message);

                context.Response.StatusCode = 500;
            }
            finally
            {
                _logger.Information("Request completed: {StatusCode} {Method} {Path}", context.Response.StatusCode, context.Request.Method, context.Request.Path);
            }
        }
    }
}

