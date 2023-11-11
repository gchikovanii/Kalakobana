using Kalakobana.Domain.Cities;
using Kalakobana.Domain.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Infrastructure.Repositories.Cities
{
    public interface ICityRepository
    {
        Task<int> CreateAsync(CancellationToken cancellationToken, City country);
        Task<bool> UpdateAsync(CancellationToken cancellationToken, string name, string newName);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, string name);
        Task<bool> Exists(CancellationToken cancellationToken, string name);
    }
}
