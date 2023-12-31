﻿using Kalakobana.Domain.Countries;
using Kalakobana.Infrastructure.Repositories.Countries;
using Kalakobana.Infrastructure.Units;
using Mapster;
using MediatR;


namespace Kalakobana.Application.Countries.Commands
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, bool>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCountryCommandHandler(ICountryRepository countryRepository, IUnitOfWork unitOfWork)
        {
            _countryRepository = countryRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _countryRepository.CreateAsync(cancellationToken, request.Adapt<Country>()).ConfigureAwait(false);
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
