using Dapper;
using Kalakobana.Application.Infrastructure.Connections;
using Kalakobana.Application.Movies.Reponses;
using MediatR;
using Microsoft.Data.SqlClient;


namespace Kalakobana.Application.Movies.Queries
{
    public class GetFilteredMoviesQueryHandler : IRequestHandler<GetFilteredMoviesQuery, List<MovieResponseModel>>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetFilteredMoviesQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<MovieResponseModel>> Handle(GetFilteredMoviesQuery request, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _connectionFactory.CreateConnection();
            var result = await sqlConnection.QueryAsync<MovieResponseModel>
                 (@"SELECT Id,Name
                    FROM Movies 
                    where Name like @c + '%'",
             new
             {
                 c = request.Letter
             });
            return result.ToList();
        }
    }
}
