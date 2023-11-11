using Kalakobana.Domain.LastNames;
using Kalakobana.Infrastructure.Repositories.LastNames;
using Mapster;
using MediatR;


namespace Kalakobana.Application.LastNames
{
    public class CreateLastNameCommandHandler : IRequestHandler<CreateLastNameCommand, int>
    {
        private readonly ILastNameRepository _lastNameRepository;

        public CreateLastNameCommandHandler(ILastNameRepository lastNameRepository)
        {
            _lastNameRepository = lastNameRepository;
        }
        public async Task<int> Handle(CreateLastNameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _lastNameRepository.CreateAsync(cancellationToken, request.Adapt<LastName>()).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
