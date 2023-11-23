using Kalakobana.API.Infrastructure.Middlewares;
namespace Kalakobana.API.Infrastructure.Extensions
{
    public static class GlobalExceptionHandlingMiddleware
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
