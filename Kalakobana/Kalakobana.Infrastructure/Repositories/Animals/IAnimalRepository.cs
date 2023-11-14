using Kalakobana.Domain.Animals;
using Kalakobana.Domain.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Infrastructure.Repositories.Animals
{
    public interface IAnimalRepository
    {
        Task CreateAsync(CancellationToken cancellationToken, Animal animal);
        Task UpdateAsync(CancellationToken cancellationToken, string name, string newName, AnimalType animalType);
        Task DeleteAsync(CancellationToken cancellationToken, string name);
        Task<bool> Exists(CancellationToken cancellationToken, string name);
    }
}
