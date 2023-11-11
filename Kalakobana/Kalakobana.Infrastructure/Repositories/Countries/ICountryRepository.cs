using Kalakobana.Domain.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Infrastructure.Repositories.Countries
{
    public interface ICountryRepository
    {
        Task<int> CreateAsync(CancellationToken cancellationToken, Country country);
        Task<bool> UpdateAsync(CancellationToken cancellationToken, Country country);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, string name);
        Task<bool> Exists(CancellationToken cancellationToken, string name);
    }
}
