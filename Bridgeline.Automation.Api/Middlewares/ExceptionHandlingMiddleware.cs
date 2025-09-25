using Bridgeline.Automation.Application.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Bridgeline.Automation.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");

                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            string message = exception.Message;

            switch (exception)
            {
                case ConflictException:
                    status = HttpStatusCode.Conflict; // 409
                    break;

                case NotFoundException:
                    status = HttpStatusCode.NotFound; // 404
                    break;

                case ValidationException:
                    status = HttpStatusCode.BadRequest; // 400
                    break;

                default:
                    status = HttpStatusCode.InternalServerError; // 500
                    break;
            }

            var result = new
            {
                statusCode = (int)status,
                error = message
            };

            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsJsonAsync(result);
        }
    }
}
