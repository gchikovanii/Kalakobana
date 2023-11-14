using Kalakobana.Application.Infrastructure.Connections;
using Kalakobana.Infrastructure.Repositories.Animals;
using Kalakobana.Infrastructure.Repositories.Base;
using Kalakobana.Infrastructure.Repositories.Cities;
using Kalakobana.Infrastructure.Repositories.Countries;
using Kalakobana.Infrastructure.Repositories.FirstNames;
using Kalakobana.Infrastructure.Repositories.LastNames;
using Kalakobana.Infrastructure.Repositories.Movies;
using Kalakobana.Infrastructure.Repositories.Plants;
using Kalakobana.Infrastructure.Units;

namespace Kalakobana.API.Infrastructure.Extensions
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IFirstNameRepository, FirstNameRepository>();
            services.AddScoped<ILastNameRepository, LastNameRepository>();
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<IPlantRepository, PlantRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();


        }
    }
}
