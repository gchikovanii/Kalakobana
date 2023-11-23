using Kalakobana.API.Infrastructure.Middlewares;

namespace Kalakobana.API.Infrastructure.Extensions
{
    public static class CultureMiddlewareExtension
    {
        public static IApplicationBuilder UseCulture(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CultureConfigMiddleware>();
        }
    }
}
