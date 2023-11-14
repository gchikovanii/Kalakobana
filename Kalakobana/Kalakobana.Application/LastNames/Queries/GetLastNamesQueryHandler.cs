using Dapper;
using Kalakobana.Application.Countries.Queries;
using Kalakobana.Application.Countries.Responses;
using Kalakobana.Application.Infrastructure.Connections;
using Kalakobana.Application.LastNames.Responses;
using Mapster;
using MediatR;
using Microsoft.Data.SqlClient;

namespace Kalakobana.Application.LastNames.Queries
{
    public class GetLastNamesQueryHandler : IRequestHandler<GetLastNamesQuery, List<LastNameReposne>>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetLastNamesQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<LastNameReposne>> Handle(GetLastNamesQuery request, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _connectionFactory.CreateConnection();
            var result = await sqlConnection.QueryAsync
                 (@"SELECT *
                    FROM LastNames");
            return result.Adapt<List<LastNameReposne>>();
        }
    }
}
