using Kalakobana.Domain.Names;
using Kalakobana.Infrastructure.Repositories.FirstNames;
using Mapster;
using MediatR;

namespace Kalakobana.Application.FirstNames.Commands
{
    public class CreateFirstNameCommandHandler : IRequestHandler<CreateFirstNameCommand, int>
    {
        private readonly IFirstNameRepository _firstNameRepository;

        public CreateFirstNameCommandHandler(IFirstNameRepository firstNameRepository)
        {
            _firstNameRepository = firstNameRepository;
        }
        public async Task<int> Handle(CreateFirstNameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _firstNameRepository.CreateAsync(cancellationToken, request.Adapt<FirstName>()).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
