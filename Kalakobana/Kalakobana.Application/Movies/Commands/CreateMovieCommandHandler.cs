using Kalakobana.Domain.Movies;
using Kalakobana.Infrastructure.Repositories.Movies;
using Kalakobana.Infrastructure.Units;
using Mapster;
using MediatR;


namespace Kalakobana.Application.Movies.Commands
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, bool>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateMovieCommandHandler(IMovieRepository movieRepository, IUnitOfWork unitOfWork)
        {
            _movieRepository = movieRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _movieRepository.CreateAsync(cancellationToken, request.Adapt<Movie>()).ConfigureAwait(false);
                var result = await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
