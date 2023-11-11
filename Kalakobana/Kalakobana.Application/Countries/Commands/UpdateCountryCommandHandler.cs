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
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, bool>
    {
        private readonly ICountryRepository _countryRepository;

        public UpdateCountryCommandHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<bool> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            return await _countryRepository.UpdateAsync(cancellationToken,request.Adapt<Country>()).ConfigureAwait(false);
        }
    }
}
