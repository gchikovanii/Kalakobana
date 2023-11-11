using Kalakobana.Infrastructure.Repositories.Countries;
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
            return await _countryRepository.DeleteAsync(cancellationToken,request.Name).ConfigureAwait(false);
        }
    }
}
