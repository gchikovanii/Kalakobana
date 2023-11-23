using Kalakobana.Infrastructure.Errors;
using Kalakobana.Infrastructure.Localizations;
using Kalakobana.Infrastructure.Repositories.Movies;
using Kalakobana.Infrastructure.Units;
using MediatR;

namespace Kalakobana.Application.Movies.Commands
{
    public class UpdateMovieCommandHandler: IRequestHandler<UpdateMovieCommand, bool>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateMovieCommandHandler(IMovieRepository movieRepository, IUnitOfWork unitOfWork)
        {
            _movieRepository = movieRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _movieRepository.UpdateAsync(cancellationToken, request.Name, request.NewName).ConfigureAwait(false);
                var result = await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                if (result == false)
                    throw new NotFoundException(ErrorMessages.NotFound);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
