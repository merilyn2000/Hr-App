using HrApp_WebAPI.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace HrApp_WebAPI.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;

        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext http)
        {
            try
            {
                await _next(http);
            }
            catch (AccessViolationException ave)
            {
                _logger.LogError("Violation expection");
                await HandleExceptionsAsync(http, ave);
            }
            catch (UnauthorizedAccessException uae)
            {
                _logger.LogError("You must be a Manager to access this feature");
                await HandleExceptionsAsync(http, uae);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong: {e}");
                await HandleExceptionsAsync(http, e);
            }
        }

        private async Task HandleExceptionsAsync(HttpContext http, Exception exception)
        {
            http.Response.ContentType = "application/json";
            var errorCode = (int)HttpStatusCode.InternalServerError;
            var message = "";

            switch (exception)
            {
                case AccessViolationException:
                    message = "Access violation error from the custom middleware";
                    break;
                case UnauthorizedAccessException:
                    message = "Unauthorized exception error from the custom middleware";
                    break;
            }

            http.Response.StatusCode = errorCode;

            await http.Response.WriteAsync(new Errors
            {
                StatusCode = http.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
    public static class CustomExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}