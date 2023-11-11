using Kalakobana.Infrastructure.Repositories.Base;
using Kalakobana.Infrastructure.Repositories.Countries;

namespace Kalakobana.API.Infrastructure.Extensions
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}
