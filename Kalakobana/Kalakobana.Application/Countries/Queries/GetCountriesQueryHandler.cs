using Dapper;
using Kalakobana.Application.Countries.Responses;
using Kalakobana.Application.Infrastructure.Connections;
using Mapster;
using MediatR;
using Microsoft.Data.SqlClient;


namespace Kalakobana.Application.Countries.Queries
{
    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, List<CountryResponseModel>>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetCountriesQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<CountryResponseModel>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _connectionFactory.CreateConnection();
            var result = await sqlConnection.QueryAsync
                 (@"SELECT *
                    FROM countries");
            return result.Adapt<List<CountryResponseModel>>();
        }
    }
}
