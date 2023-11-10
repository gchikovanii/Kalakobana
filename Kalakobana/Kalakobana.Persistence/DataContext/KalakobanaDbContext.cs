using Kalakobana.Domain.Animals;
using Kalakobana.Domain.Cities;
using Kalakobana.Domain.Countries;
using Kalakobana.Domain.LastNames;
using Kalakobana.Domain.Movies;
using Kalakobana.Domain.Names;
using Kalakobana.Domain.Plants;
using Microsoft.EntityFrameworkCore;

namespace Kalakobana.Persistence.DataContext
{
    public class KalakobanaDbContext : DbContext
    {
        public KalakobanaDbContext(DbContextOptions<KalakobanaDbContext> options) : base(options)
        {
        }

        public DbSet<FirstName> FirstNames { get; set; }
        public DbSet<LastName> LastNames { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KalakobanaDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
