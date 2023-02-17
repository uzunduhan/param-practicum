using PracticumHomeWork.Middlewares;

namespace PracticumHomeWork.Extensions
{
    public static class RequestResponseExtensions
    {
        public static IApplicationBuilder UseRequestResponseMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestResponseMiddleware>();
        }
    }
}
