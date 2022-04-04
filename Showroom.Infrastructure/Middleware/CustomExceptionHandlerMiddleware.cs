using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Showroom.Infrastructure.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next) => _next = next;

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

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode code = HttpStatusCode.InternalServerError;
            string? result = string.Empty;
            switch (ex)
            {
                case Exception exception:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(new { error = ex.Message });
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
                result = JsonSerializer.Serialize(new { error = ex.Message });

            return context.Response.WriteAsync(result);
        }
    }
}
