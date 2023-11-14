using Kalakobana.Application.Movies.Reponses;
using MediatR;

namespace Kalakobana.Application.Movies.Queries
{
    public class GetFilteredMoviesQuery : IRequest<List<MovieResponseModel>>
    {
        public string Letter { get; set; }
    }
}
