using Kalakobana.Domain.LastNames;


namespace Kalakobana.Infrastructure.Repositories.LastNames
{
    public interface ILastNameRepository
    {
        Task<int> CreateAsync(CancellationToken cancellationToken, LastName country);
        Task UpdateAsync(CancellationToken cancellationToken, string name, string newName);
        Task DeleteAsync(CancellationToken cancellationToken, string name);
        Task<bool> Exists(CancellationToken cancellationToken, string name);
    }
}
