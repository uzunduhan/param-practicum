using System.Diagnostics;

namespace PracticumHomeWork.Middlewares
{
    public class RequestResponseMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseMiddleware> _logger;

        public RequestResponseMiddleware(RequestDelegate next, ILogger<RequestResponseMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();


            //request
            string message = "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path;
            _logger.LogInformation(message);

            await _next.Invoke(context); //response creating

            //the response will be here
            message = "[Response] HTTP " + context.Request.Method + " - " + context.Request.Path + " responded " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + " ms";
            _logger.LogInformation(message);



        }
    }
}
