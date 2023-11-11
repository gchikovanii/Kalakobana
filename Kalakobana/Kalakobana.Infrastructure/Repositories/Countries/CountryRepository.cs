using Kalakobana.Domain.Countries;
using Kalakobana.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Kalakobana.Infrastructure.Repositories.Countries
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IBaseRepository<Country> _countryRepository;

        public CountryRepository(IBaseRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<int> CreateAsync(CancellationToken cancellationToken, Country country)
        {
            await _countryRepository.AddAsync(country,cancellationToken);
            await _countryRepository.SaveChangesAsync(cancellationToken);
            return country.Id;
        }
        public async Task<bool> UpdateAsync(CancellationToken cancellationToken, string name, string newName)
        {
            var entity = await _countryRepository.Table.FirstOrDefaultAsync(i => i.Name == name);
            if (entity == null)
                throw new Exception();
            entity.Name = newName;
            _countryRepository.Update(entity, cancellationToken);
            return await _countryRepository.SaveChangesAsync(cancellationToken);
        }
        public async Task<bool> DeleteAsync(CancellationToken cancellationToken, string name)
        {
            var entity = await _countryRepository.Table.SingleOrDefaultAsync(i => i.Name == name);
            if(entity == null)
                throw new Exception();
            await _countryRepository.RemoveAsync(cancellationToken,entity.Id);
            return await _countryRepository.SaveChangesAsync(cancellationToken);
        }
        public async Task<bool> Exists(CancellationToken cancellationToken, string name)
        {
            return await _countryRepository.AnyAsync(i => i.Name == name, cancellationToken);
        }
    }
}
