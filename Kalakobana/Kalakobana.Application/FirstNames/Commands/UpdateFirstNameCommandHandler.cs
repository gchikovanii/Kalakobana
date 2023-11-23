using Kalakobana.Infrastructure.Errors;
using Kalakobana.Infrastructure.Localizations;
using Kalakobana.Infrastructure.Repositories.FirstNames;
using Kalakobana.Infrastructure.Units;
using MediatR;


namespace Kalakobana.Application.FirstNames.Commands
{
    public class UpdateFirstNameCommandHandler : IRequestHandler<UpdateFirstNameCommand, bool>
    {
        private readonly IFirstNameRepository _firstNameRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateFirstNameCommandHandler(IFirstNameRepository firstNameRepository, IUnitOfWork unitOfWork)
        {
            _firstNameRepository = firstNameRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateFirstNameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _firstNameRepository.UpdateAsync(cancellationToken, request.Name, request.NewName).ConfigureAwait(false);
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
