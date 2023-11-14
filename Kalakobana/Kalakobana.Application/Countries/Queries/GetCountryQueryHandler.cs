using Dapper;
using Kalakobana.Application.Countries.Responses;
using Kalakobana.Application.Infrastructure.Connections;
using Kalakobana.Domain.Countries;
using MediatR;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Countries.Queries
{
    public class GetCountryQueryHandler : IRequestHandler<GetCountryQuery, CountryResponseModel>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetCountryQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<CountryResponseModel> Handle(GetCountryQuery request, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _connectionFactory.CreateConnection();
            var result = await sqlConnection.QueryFirstOrDefaultAsync<CountryResponseModel>
                 (@"SELECT Id,Name
                    FROM countries 
                    where Name =@CountryId",
             new
             {
                 CountryId = request.Name
             });
            return result;
        }
    }
}
