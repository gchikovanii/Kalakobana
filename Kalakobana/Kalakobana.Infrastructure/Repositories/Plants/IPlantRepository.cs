using Kalakobana.Domain.Cities;
using Kalakobana.Domain.Plants;

namespace Kalakobana.Infrastructure.Repositories.Plants
{
    public interface IPlantRepository
    {
        Task<int> CreateAsync(CancellationToken cancellationToken, Plant plant);
        Task<bool> UpdateAsync(CancellationToken cancellationToken, string name, string newName);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, string name);
        Task<bool> Exists(CancellationToken cancellationToken, string name);
    }
}
