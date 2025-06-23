using Domain.Exceptions;
using Shared.ErrorModels;
using System.Net;
using System.Text.Json;

namespace E_Commerce.Middlewares
{
    public class CustomExceptionHadlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHadlerMiddleware> _logger;

        public CustomExceptionHadlerMiddleware(RequestDelegate next, 
            ILogger<CustomExceptionHadlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {

            try
            {
                await _next.Invoke(httpContext); // Compilation error here ?? 
                                                 // Logic 
                await HandleNotFoundEndPointAsync(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong!!");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {

            // Set Status Code
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            // Set Content Type 
            httpContext.Response.ContentType = "application/json";
            // Response Object 
            var response = new ErrorDetails
            {
                ErrorMessage = ex.Message
            };

            response.StatusCode = ex switch
            {
                NotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError,
            };
            // return response as a JSON 
            //var jsonResult = JsonSerializer.Serialize(response);

            httpContext.Response.StatusCode = response.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(response);
        }
        private static async Task HandleNotFoundEndPointAsync(HttpContext httpContext)
        {
            if (httpContext.Response.StatusCode == (int)HttpStatusCode.NotFound)
            {
                httpContext.Response.ContentType = "application/json";
                var response = new ErrorDetails
                {
                    ErrorMessage = $"End Point {httpContext.Request.Path} Not Found",
                    StatusCode = (int)HttpStatusCode.NotFound
                };
                await httpContext.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
