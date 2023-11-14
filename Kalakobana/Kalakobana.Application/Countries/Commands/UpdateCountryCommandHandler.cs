using Kalakobana.Application.Errors.Custom;
using Kalakobana.Domain.Countries;
using Kalakobana.Infrastructure.Repositories.Countries;
using Kalakobana.Infrastructure.Units;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
