using Dapper;
using Kalakobana.Application.Cities.responses;
using Kalakobana.Application.Infrastructure.Connections;
using Mapster;
using MediatR;
using Microsoft.Data.SqlClient;


namespace Kalakobana.Application.Cities.Queries
{
    public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, List<CityReponseModel>>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetCitiesQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<CityReponseModel>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _connectionFactory.CreateConnection();
            var result = await sqlConnection.QueryAsync
                 (@"SELECT *
                    FROM Cities");
            return result.Adapt<List<CityReponseModel>>();
        }
    }
}
