using Kalakobana.Application.Countries.Responses;
using Kalakobana.Application.Movies.Reponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Movies.Queries
{
    public class GetMoviesQuery : IRequest<List<MovieResponseModel>>
    {
    }
}
