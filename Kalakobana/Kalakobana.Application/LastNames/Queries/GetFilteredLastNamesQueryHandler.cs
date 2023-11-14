using Dapper;
using Kalakobana.Application.Infrastructure.Connections;
using Kalakobana.Application.LastNames.Responses;
using MediatR;
using Microsoft.Data.SqlClient;


namespace Kalakobana.Application.LastNames.Queries
{
    public class GetFilteredLastNamesQueryHandler : IRequestHandler<GetFilteredLastNamesQuery, List<LastNameReposne>>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetFilteredLastNamesQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<LastNameReposne>> Handle(GetFilteredLastNamesQuery request, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _connectionFactory.CreateConnection();
            var result = await sqlConnection.QueryAsync<LastNameReposne>
                 (@"SELECT Id,Name
                    FROM LastNames 
                    where Name like @c + '%'",
             new
             {
                 c = request.Letter
             });
            return result.ToList();
        }
    }
}
