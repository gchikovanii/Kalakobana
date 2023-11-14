using Kalakobana.Domain.Plants;

namespace Kalakobana.Infrastructure.Repositories.Plants
{
    public interface IPlantRepository
    {
        Task CreateAsync(CancellationToken cancellationToken, Plant plant);
        Task UpdateAsync(CancellationToken cancellationToken, string name, string newName);
        Task DeleteAsync(CancellationToken cancellationToken, string name);
        Task<bool> Exists(CancellationToken cancellationToken, string name);
    }
}
