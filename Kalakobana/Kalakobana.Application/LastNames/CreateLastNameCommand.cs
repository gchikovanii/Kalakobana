using MediatR;


namespace Kalakobana.Application.LastNames
{
    public class CreateLastNameCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}