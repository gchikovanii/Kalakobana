using Dapper;
using Kalakobana.Application.Animals.Responses;
using Kalakobana.Application.Countries.Queries;
using Kalakobana.Application.Countries.Responses;
using Kalakobana.Application.Infrastructure.Connections;
using Mapster;
using MediatR;
using Microsoft.Data.SqlClient;

namespace Kalakobana.Application.Animals.Queries
{
    public class GetFilteredAnimalsQueryHandler : IRequestHandler<GetFilteredAnimalsQuery, List<AnimalResponseModel>>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetFilteredAnimalsQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<List<AnimalResponseModel>> Handle(GetFilteredAnimalsQuery request, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _connectionFactory.CreateConnection();
            var result = await sqlConnection.QueryAsync<AnimalResponseModel>
                 (@"SELECT Id,Name,AnimalType
                    FROM Animals 
                    where Name like @c + '%'",
             new
             {
                 c = request.Letter
             });
            return result.ToList();
        }
    }
}
