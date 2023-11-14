using Kalakobana.Domain.Cities;
using Kalakobana.Infrastructure.Repositories.Cities;
using Kalakobana.Infrastructure.Units;
using Mapster;
using MediatR;


namespace Kalakobana.Application.Cities.Commands
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, bool>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCityCommandHandler(ICityRepository cityRepository, IUnitOfWork unitOfWork)
        {
            _cityRepository = cityRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _cityRepository.CreateAsync(cancellationToken, request.Adapt<City>()).ConfigureAwait(false);
                var result = await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
