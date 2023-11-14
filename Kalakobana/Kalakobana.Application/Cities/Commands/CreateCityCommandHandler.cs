using Kalakobana.Application.Animals.Commands;
using Kalakobana.Domain.Animals;
using Kalakobana.Domain.Cities;
using Kalakobana.Infrastructure.Repositories.Animals;
using Kalakobana.Infrastructure.Repositories.Cities;
using Kalakobana.Infrastructure.Units;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Cities.Commands
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, int>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCityCommandHandler(ICityRepository cityRepository, IUnitOfWork unitOfWork)
        {
            _cityRepository = cityRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result =  await _cityRepository.CreateAsync(cancellationToken, request.Adapt<City>()).ConfigureAwait(false);
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
