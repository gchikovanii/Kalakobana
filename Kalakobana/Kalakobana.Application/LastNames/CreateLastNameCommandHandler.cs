using Kalakobana.Domain.LastNames;
using Kalakobana.Infrastructure.Repositories.LastNames;
using Kalakobana.Infrastructure.Units;
using Mapster;
using MediatR;


namespace Kalakobana.Application.LastNames
{
    public class CreateLastNameCommandHandler : IRequestHandler<CreateLastNameCommand, int>
    {
        private readonly ILastNameRepository _lastNameRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateLastNameCommandHandler(ILastNameRepository lastNameRepository, IUnitOfWork unitOfWork)
        {
            _lastNameRepository = lastNameRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateLastNameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _lastNameRepository.CreateAsync(cancellationToken, request.Adapt<LastName>()).ConfigureAwait(false);
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
