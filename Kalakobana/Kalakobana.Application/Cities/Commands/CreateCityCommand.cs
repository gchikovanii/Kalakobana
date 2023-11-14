using MediatR;

namespace Kalakobana.Application.Cities.Commands
{
    public class CreateCityCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
