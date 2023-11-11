using Kalakobana.Application.Errors.Custom;
using Kalakobana.Infrastructure.Repositories.Cities;
using MediatR;


namespace Kalakobana.Application.Cities.Commands
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, bool>
    {
        private readonly ICityRepository _cityRepository;

        public UpdateCityCommandHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<bool> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _cityRepository.UpdateAsync(cancellationToken, request.Name, request.NewName).ConfigureAwait(false);

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
