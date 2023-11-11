using Kalakobana.Application.Errors.Custom;
using Kalakobana.Domain.Countries;
using Kalakobana.Infrastructure.Repositories.Countries;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Countries.Commands
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCommand, bool>
    {
        private readonly ICountryRepository _countryRepository;

        public DeleteCountryCommandHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _countryRepository.DeleteAsync(cancellationToken, request.Name);
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
