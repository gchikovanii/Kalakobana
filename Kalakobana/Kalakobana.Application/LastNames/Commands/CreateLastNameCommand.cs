using MediatR;


namespace Kalakobana.Application.LastNames.Commands
{
    public class CreateLastNameCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}