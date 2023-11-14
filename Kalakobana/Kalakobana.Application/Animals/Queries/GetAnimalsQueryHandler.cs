using Dapper;
using Kalakobana.Application.Animals.Responses;
using Kalakobana.Application.Infrastructure.Connections;
using Mapster;
using MediatR;
using Microsoft.Data.SqlClient;

namespace Kalakobana.Application.Animals.Queries
{
    public class GetAnimalsQueryHandler : IRequestHandler<GetAnimalsQuery, List<AnimalResponseModel>>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetAnimalsQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<AnimalResponseModel>> Handle(GetAnimalsQuery request, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _connectionFactory.CreateConnection();
            var result = await sqlConnection.QueryAsync
                 (@"SELECT *
                    FROM Animals");
            return result.Adapt<List<AnimalResponseModel>>();
        }
    }
}
