using Kalakobana.Application.Infrastructure.Errors.Custom;
using Kalakobana.Infrastructure.Repositories.Countries;
using Kalakobana.Infrastructure.Units;
using MediatR;


namespace Kalakobana.Application.Countries.Commands
{
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, bool>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCountryCommandHandler(ICountryRepository countryRepository, IUnitOfWork unitOfWork)
        {
            _countryRepository = countryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _countryRepository.UpdateAsync(cancellationToken, request.Name, request.NewName).ConfigureAwait(false);
                var result = await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                if(result == false)
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
