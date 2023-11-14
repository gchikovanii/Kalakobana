using Dapper;
using Kalakobana.Application.Animals.Responses;
using Kalakobana.Application.Infrastructure.Connections;
using Kalakobana.Domain.Animals;
using MediatR;
using Microsoft.Data.SqlClient;


namespace Kalakobana.Application.Animals.Queries
{
    public class GetAnimalsByCategoryQueryHandler : IRequestHandler<GetAnimalsByCategoryQuery, List<AnimalResponseModel>>
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        public GetAnimalsByCategoryQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<List<AnimalResponseModel>> Handle(GetAnimalsByCategoryQuery request, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _connectionFactory.CreateConnection();
            //int animalTypeValue = (int)request.AnimalType;
            AnimalType animalType = Enum.Parse<AnimalType>(request.AnimalType.ToString(), true);
            int animalTypeValue = (int)animalType;
            var result = await sqlConnection.QueryAsync<AnimalResponseModel>(
                @"SELECT Id, Name, AnimalType
           FROM Animals 
           WHERE AnimalType = @c",
                new { c = animalTypeValue });

            return result.ToList();
        }
    }
}
