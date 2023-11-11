﻿using Kalakobana.Domain.Countries;
using Kalakobana.Infrastructure.Repositories.Countries;
using Mapster;
using MediatR;


namespace Kalakobana.Application.Countries.Commands
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, int>
    {
        private readonly ICountryRepository _countryRepository;

        public CreateCountryCommandHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public async Task<int> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            return await _countryRepository.CreateAsync(cancellationToken, request.Adapt<Country>()).ConfigureAwait(false);
        }
    }
}
