using MediatR;


namespace Kalakobana.Application.FirstNames.Commands
{
    public class CreateFirstNameCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}