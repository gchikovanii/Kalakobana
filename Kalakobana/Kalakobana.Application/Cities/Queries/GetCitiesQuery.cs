using Kalakobana.Application.Cities.responses;
using MediatR;


namespace Kalakobana.Application.Cities.Queries
{
    public class GetCitiesQuery : IRequest<List<CityReponseModel>>
    {
    }
}