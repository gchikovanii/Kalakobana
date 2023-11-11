using Kalakobana.Domain.LastNames;
using Kalakobana.Domain.Movies;
using Kalakobana.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Kalakobana.Infrastructure.Repositories.Movies
{
    public class MovieRepository : IMovieRepository
    {

        private readonly IBaseRepository<Movie> _movieRepository;

        public MovieRepository(IBaseRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<int> CreateAsync(CancellationToken cancellationToken, Movie movie)
        {
            await _movieRepository.AddAsync(movie, cancellationToken);
            await _movieRepository.SaveChangesAsync(cancellationToken);
            return movie.Id;
        }
        public async Task<bool> UpdateAsync(CancellationToken cancellationToken, string name, string newName)
        {
            var entity = await _movieRepository.Table.FirstOrDefaultAsync(i => i.Name == name);
            if (entity == null)
                throw new Exception();
            entity.Name = newName;
            _movieRepository.Update(entity, cancellationToken);
            return await _movieRepository.SaveChangesAsync(cancellationToken);
        }
        public async Task<bool> DeleteAsync(CancellationToken cancellationToken, string name)
        {
            var entity = await _movieRepository.Table.SingleOrDefaultAsync(i => i.Name == name);
            if (entity == null)
                throw new Exception();
            await _movieRepository.RemoveAsync(cancellationToken, entity.Id);
            return await _movieRepository.SaveChangesAsync(cancellationToken);
        }
        public async Task<bool> Exists(CancellationToken cancellationToken, string name)
        {
            return await _movieRepository.AnyAsync(i => i.Name == name, cancellationToken);
        }
    }
}
