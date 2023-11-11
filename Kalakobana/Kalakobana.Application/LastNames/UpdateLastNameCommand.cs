using MediatR;

namespace Kalakobana.Application.LastNames
{
    public class UpdateLastNameCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string NewName { get; set; }
    }
}