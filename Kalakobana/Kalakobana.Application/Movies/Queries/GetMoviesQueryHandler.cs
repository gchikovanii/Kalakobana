using Dapper;
using Kalakobana.Application.Infrastructure.Connections;
using Kalakobana.Application.Movies.Reponses;
using Mapster;
using MediatR;
using Microsoft.Data.SqlClient;


namespace Kalakobana.Application.Movies.Queries
{
    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, List<MovieResponseModel>>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetMoviesQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<MovieResponseModel>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _connectionFactory.CreateConnection();
            var result = await sqlConnection.QueryAsync
                 (@"SELECT *
                    FROM Movies");
            return result.Adapt<List<MovieResponseModel>>();
        }
    }
}
