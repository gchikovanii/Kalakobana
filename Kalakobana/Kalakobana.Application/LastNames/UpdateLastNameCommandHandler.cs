using Kalakobana.Application.Infrastructure.Errors.Custom;
using Kalakobana.Infrastructure.Repositories.LastNames;
using Kalakobana.Infrastructure.Units;
using MediatR;

namespace Kalakobana.Application.LastNames
{
    public class UpdateLastNameCommandHandler : IRequestHandler<UpdateLastNameCommand, bool>
    {
        private readonly ILastNameRepository _lastNameRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateLastNameCommandHandler(ILastNameRepository lastNameRepository, IUnitOfWork unitOfWork)
        {
            _lastNameRepository = lastNameRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateLastNameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _lastNameRepository.UpdateAsync(cancellationToken, request.Name, request.NewName).ConfigureAwait(false);
                var result = await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                if (result == false)
                    throw new NotFoundException("Not Found");
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
