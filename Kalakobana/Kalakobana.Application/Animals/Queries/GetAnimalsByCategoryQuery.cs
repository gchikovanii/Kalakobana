using Kalakobana.Application.Animals.Responses;
using Kalakobana.Domain.Animals;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kalakobana.Application.Animals.Queries
{
    public class GetAnimalsByCategoryQuery : IRequest<List<AnimalResponseModel>>
    {
        [FromQuery]
        public AnimalType AnimalType { get; set; }
    }
}

