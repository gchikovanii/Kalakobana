using Kalakobana.Domain.Movies;
using Kalakobana.Infrastructure.Repositories.Movies;
using Kalakobana.Infrastructure.Units;
using Mapster;
using MediatR;


namespace Kalakobana.Application.Movies.Commands
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, int>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateMovieCommandHandler(IMovieRepository movieRepository, IUnitOfWork unitOfWork)
        {
            _movieRepository = movieRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _movieRepository.CreateAsync(cancellationToken, request.Adapt<Movie>()).ConfigureAwait(false);
                await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
