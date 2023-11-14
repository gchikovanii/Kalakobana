using Dapper;
using Kalakobana.Application.Infrastructure.Connections;
using Kalakobana.Application.Plants.Responses;
using Mapster;
using MediatR;
using Microsoft.Data.SqlClient;


namespace Kalakobana.Application.Plants.Queries
{
    public class GetPlantsQueryHandler : IRequestHandler<GetPlantsQuery, List<PlantReponseModel>>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetPlantsQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<PlantReponseModel>> Handle(GetPlantsQuery request, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _connectionFactory.CreateConnection();
            var result = await sqlConnection.QueryAsync
                 (@"SELECT *
                    FROM Plants");
            return result.Adapt<List<PlantReponseModel>>();
        }
    }
}
