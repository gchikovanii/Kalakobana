using Kalakobana.Domain.Movies;
using Kalakobana.Infrastructure.Repositories.Movies;
using Mapster;
using MediatR;


namespace Kalakobana.Application.Movies.Commands
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, int>
    {
        private readonly IMovieRepository _movieRepository;

        public CreateMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<int> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _movieRepository.CreateAsync(cancellationToken, request.Adapt<Movie>()).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
