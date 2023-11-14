using Kalakobana.Application.Animals.Commands;
using Kalakobana.Application.Errors.Custom;
using Kalakobana.Infrastructure.Repositories.Animals;
using Kalakobana.Infrastructure.Repositories.Cities;
using Kalakobana.Infrastructure.Units;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Cities.Commands
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, bool>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCityCommandHandler(ICityRepository deleteCityRepository, IUnitOfWork unitOfWork)
        {
            _cityRepository = deleteCityRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _cityRepository.DeleteAsync(cancellationToken, request.Name);
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
