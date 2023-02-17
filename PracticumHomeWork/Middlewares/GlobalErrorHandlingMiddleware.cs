using System.Net;
using System.Text.Json;
using PracticumHomeWork.Controllers;

namespace PracticumHomeWork.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MovieController> _logger;

        public GlobalErrorHandlingMiddleware(RequestDelegate next, ILogger<MovieController> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {

                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var errorResponse = new
                {
                    message = ex.Message,
                    statusCode = response.StatusCode
                };

                var errorJson = JsonSerializer.Serialize(errorResponse);
                _logger.LogError(errorJson);

                await response.WriteAsync(errorJson);
            }
        }
    }

}
