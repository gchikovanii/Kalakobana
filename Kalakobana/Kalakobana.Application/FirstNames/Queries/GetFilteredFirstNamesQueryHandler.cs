using Dapper;
using Kalakobana.Application.Countries.Queries;
using Kalakobana.Application.Countries.Responses;
using Kalakobana.Application.FirstNames.Response;
using Kalakobana.Application.Infrastructure.Connections;
using MediatR;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.FirstNames.Queries
{
    public class GetFilteredFirstNamesQueryHandler : IRequestHandler<GetFilteredFirstNamesQuery, List<FirstNameReposneModel>>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetFilteredFirstNamesQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<FirstNameReposneModel>> Handle(GetFilteredFirstNamesQuery request, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _connectionFactory.CreateConnection();
            var result = await sqlConnection.QueryAsync<FirstNameReposneModel>
                 (@"SELECT Id,Name
                    FROM FirstNames 
                    where Name like @c + '%'",
             new
             {
                 c = request.Letter
             });
            return result.ToList();
        }
    }
}
