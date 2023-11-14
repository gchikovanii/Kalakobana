using Kalakobana.Domain.Names;
using Kalakobana.Infrastructure.Repositories.FirstNames;
using Kalakobana.Infrastructure.Units;
using Mapster;
using MediatR;

namespace Kalakobana.Application.FirstNames.Commands
{
    public class CreateFirstNameCommandHandler : IRequestHandler<CreateFirstNameCommand, int>
    {
        private readonly IFirstNameRepository _firstNameRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateFirstNameCommandHandler(IFirstNameRepository firstNameRepository, IUnitOfWork unitOfWork)
        {
            _firstNameRepository = firstNameRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateFirstNameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _firstNameRepository.CreateAsync(cancellationToken, request.Adapt<FirstName>()).ConfigureAwait(false);
                await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
