using Kalakobana.Infrastructure.Errors;
using Kalakobana.Infrastructure.Localizations;
using Kalakobana.Infrastructure.Repositories.LastNames;
using Kalakobana.Infrastructure.Units;
using MediatR;


namespace Kalakobana.Application.LastNames.Commands
{
    public class DeleteLastNameCommandHandler : IRequestHandler<DeleteLastNameCommand, bool>
    {
        private readonly ILastNameRepository _lastNameRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteLastNameCommandHandler(ILastNameRepository lastNameRepository, IUnitOfWork unitOfWork)
        {
            _lastNameRepository = lastNameRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteLastNameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _lastNameRepository.DeleteAsync(cancellationToken, request.Name);
                var result = await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                if (result == false)
                    throw new NotFoundException(ErrorMessages.NotFound);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
