using Dapper;
using Kalakobana.Application.Countries.Responses;
using Kalakobana.Application.Infrastructure.Connections;
using MediatR;
using Microsoft.Data.SqlClient;


namespace Kalakobana.Application.Countries.Queries
{
    public class GetFilteredCountriesQueryHandler : IRequestHandler<GetFilteredCountriesQuery, List<CountryResponseModel>>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetFilteredCountriesQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<CountryResponseModel>> Handle(GetFilteredCountriesQuery request, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _connectionFactory.CreateConnection();
            var result = await sqlConnection.QueryAsync<CountryResponseModel>
                 (@"SELECT Id,Name
                    FROM countries 
                    where Name like @c + '%'",
             new
             {
                 c = request.Letter
             });
            return result.ToList();
        }
    }
}
