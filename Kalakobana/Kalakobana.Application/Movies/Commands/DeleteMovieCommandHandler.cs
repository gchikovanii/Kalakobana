using Kalakobana.Application.Errors.Custom;
using Kalakobana.Infrastructure.Repositories.Movies;
using MediatR;


namespace Kalakobana.Application.Movies.Commands
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, bool>
    {
        private readonly IMovieRepository _movieRepository;

        public DeleteMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<bool> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _movieRepository.DeleteAsync(cancellationToken, request.Name);
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
