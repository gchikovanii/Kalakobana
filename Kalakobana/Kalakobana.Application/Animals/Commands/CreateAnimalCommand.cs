using Kalakobana.Domain.Animals;
using MediatR;

namespace Kalakobana.Application.Animals.Commands
{
    public class CreateAnimalCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public AnimalType AnimalType { get; set; }
    }
}
