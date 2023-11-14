using Dapper;
using Kalakobana.Application.Countries.Queries;
using Kalakobana.Application.Countries.Responses;
using Kalakobana.Application.FirstNames.Response;
using Kalakobana.Application.Infrastructure.Connections;
using Mapster;
using MediatR;
using Microsoft.Data.SqlClient;


namespace Kalakobana.Application.FirstNames.Queries
{
    public class GetFirstNamesQueryHandler : IRequestHandler<GetFirstNamesQuery, List<FirstNameReposneModel>>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetFirstNamesQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<FirstNameReposneModel>> Handle(GetFirstNamesQuery request, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _connectionFactory.CreateConnection();
            var result = await sqlConnection.QueryAsync
                 (@"SELECT *
                    FROM FirstNames");
            return result.Adapt<List<FirstNameReposneModel>>();
        }
    }
}
