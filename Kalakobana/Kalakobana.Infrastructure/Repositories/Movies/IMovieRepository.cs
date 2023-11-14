using Kalakobana.Domain.Movies;
using Kalakobana.Domain.Plants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Infrastructure.Repositories.Movies
{
    public interface IMovieRepository
    {
        Task CreateAsync(CancellationToken cancellationToken, Movie movie);
        Task UpdateAsync(CancellationToken cancellationToken, string name, string newName);
        Task DeleteAsync(CancellationToken cancellationToken, string name);
        Task<bool> Exists(CancellationToken cancellationToken, string name);
    }
}
