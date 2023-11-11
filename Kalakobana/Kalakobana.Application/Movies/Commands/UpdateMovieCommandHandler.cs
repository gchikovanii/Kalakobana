using Kalakobana.Application.Errors.Custom;
using Kalakobana.Infrastructure.Repositories.Movies;
using MediatR;

namespace Kalakobana.Application.Movies.Commands
{
    public class UpdateMovieCommandHandler: IRequestHandler<UpdateMovieCommand, bool>
    {
        private readonly IMovieRepository _movieRepository;

        public UpdateMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<bool> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _movieRepository.UpdateAsync(cancellationToken, request.Name, request.NewName).ConfigureAwait(false);

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
