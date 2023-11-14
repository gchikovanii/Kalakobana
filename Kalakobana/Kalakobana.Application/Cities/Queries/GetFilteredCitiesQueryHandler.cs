using Dapper;
using Kalakobana.Application.Cities.responses;
using Kalakobana.Application.Infrastructure.Connections;
using MediatR;
using Microsoft.Data.SqlClient;

namespace Kalakobana.Application.Cities.Queries
{
    public class GetFilteredCitiesQueryHandler : IRequestHandler<GetFilteredCitiesQuery, List<CityReponseModel>>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetFilteredCitiesQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<CityReponseModel>> Handle(GetFilteredCitiesQuery request, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _connectionFactory.CreateConnection();
            var result = await sqlConnection.QueryAsync<CityReponseModel>
                 (@"SELECT Id,Name
                    FROM Cities 
                    where Name like @c + '%'",
             new
             {
                 c = request.Letter
             });
            return result.ToList();
        }
    }
}
