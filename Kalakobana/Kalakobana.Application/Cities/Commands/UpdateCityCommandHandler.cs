using Kalakobana.Application.Infrastructure.Errors.Custom;
using Kalakobana.Infrastructure.Repositories.Cities;
using Kalakobana.Infrastructure.Units;
using MediatR;


namespace Kalakobana.Application.Cities.Commands
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, bool>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCityCommandHandler(ICityRepository cityRepository, IUnitOfWork unitOfWork)
        {
            _cityRepository = cityRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _cityRepository.UpdateAsync(cancellationToken, request.Name, request.NewName).ConfigureAwait(false);
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
