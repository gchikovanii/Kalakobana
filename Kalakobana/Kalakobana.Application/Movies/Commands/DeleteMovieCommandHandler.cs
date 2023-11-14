using Kalakobana.Application.Errors.Custom;
using Kalakobana.Infrastructure.Repositories.Movies;
using Kalakobana.Infrastructure.Units;
using MediatR;


namespace Kalakobana.Application.Movies.Commands
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, bool>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteMovieCommandHandler(IMovieRepository movieRepository, IUnitOfWork unitOfWork)
        {
            _movieRepository = movieRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _movieRepository.DeleteAsync(cancellationToken, request.Name);
                var result = await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                if (result == false)
                    throw new NotFoundException("Not Found");
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
