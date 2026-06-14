using System.Net;
using System.Text.Json;
using UnitConversionApi.Models;

namespace UnitConversionApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(
            HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Unhandled exception");

                await HandleException(
                    context,
                    ex);
            }
        }

        private static Task HandleException(
            HttpContext context,
            Exception exception)
        {
            context.Response.ContentType =
                "application/json";

            context.Response.StatusCode =
                (int)HttpStatusCode.BadRequest;

            var response = new ErrorResponse
            {
                Code = "CONVERSION_ERROR",
                Message = exception.Message,
                Timestamp = DateTime.UtcNow
            };

            return context.Response.WriteAsync(
                JsonSerializer.Serialize(response));
        }
    }
}
