﻿using Kalakobana.Domain.Cities;
using Kalakobana.Domain.LastNames;
using Kalakobana.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Kalakobana.Infrastructure.Repositories.Cities
{
    public class CityRepository : ICityRepository
    {
        private readonly IBaseRepository<City> _cityRepository;

        public CityRepository(IBaseRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task CreateAsync(CancellationToken cancellationToken, City city)
        {
            await _cityRepository.AddAsync(city, cancellationToken);
        }
        public async Task UpdateAsync(CancellationToken cancellationToken, string name, string newName)
        {
            var entity = await _cityRepository.Table.FirstOrDefaultAsync(i => i.Name == name);
            if (entity == null)
                throw new Exception();
            entity.Name = newName;
            _cityRepository.Update(entity, cancellationToken);
        }
        public async Task DeleteAsync(CancellationToken cancellationToken, string name)
        {
            var entity = await _cityRepository.Table.SingleOrDefaultAsync(i => i.Name == name);
            if (entity == null)
                throw new Exception();
            await _cityRepository.RemoveAsync(cancellationToken, entity.Id);
        }
        public async Task<bool> Exists(CancellationToken cancellationToken, string name)
        {
            return await _cityRepository.AnyAsync(i => i.Name == name, cancellationToken);
        }
    }
}

