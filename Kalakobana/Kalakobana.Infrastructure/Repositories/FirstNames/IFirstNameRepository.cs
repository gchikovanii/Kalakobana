using Kalakobana.Domain.Countries;
using Kalakobana.Domain.Names;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Infrastructure.Repositories.FirstNames
{
    public interface IFirstNameRepository
    {
        Task<int> CreateAsync(CancellationToken cancellationToken, FirstName country);
        Task<bool> UpdateAsync(CancellationToken cancellationToken, string name, string newName);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, string name);
        Task<bool> Exists(CancellationToken cancellationToken, string name);
    }
}
