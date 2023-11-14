using Dapper;
using Kalakobana.Application.Countries.Queries;
using Kalakobana.Application.Countries.Responses;
using Kalakobana.Application.Infrastructure.Connections;
using Kalakobana.Application.Plants.Responses;
using MediatR;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Plants.Queries
{
    public class GetFilteredPlantsQueryHandler : IRequestHandler<GetFilteredPlantsQuery, List<PlantReponseModel>>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetFilteredPlantsQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<PlantReponseModel>> Handle(GetFilteredPlantsQuery request, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _connectionFactory.CreateConnection();
            var result = await sqlConnection.QueryAsync<PlantReponseModel>
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
