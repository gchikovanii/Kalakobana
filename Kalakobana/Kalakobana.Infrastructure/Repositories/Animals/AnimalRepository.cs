using Kalakobana.Domain.Animals;
using Kalakobana.Domain.Countries;
using Kalakobana.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Infrastructure.Repositories.Animals
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly IBaseRepository<Animal> _animalRepository;

        public AnimalRepository(IBaseRepository<Animal> animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<int> CreateAsync(CancellationToken cancellationToken, Animal animal)
        {
            await _animalRepository.AddAsync(animal, cancellationToken);
            return animal.Id;
        }
        public async Task UpdateAsync(CancellationToken cancellationToken, string name, string newName)
        {
            var entity = await _animalRepository.Table.FirstOrDefaultAsync(i => i.Name == name);
            if (entity == null)
                throw new Exception();
            entity.Name = newName;
            _animalRepository.Update(entity, cancellationToken);
        }
        public async Task DeleteAsync(CancellationToken cancellationToken, string name)
        {
            var entity = await _animalRepository.Table.SingleOrDefaultAsync(i => i.Name == name);
            if (entity == null)
                throw new Exception();
            await _animalRepository.RemoveAsync(cancellationToken, entity.Id);
        }
        public async Task<bool> Exists(CancellationToken cancellationToken, string name)
        {
            return await _animalRepository.AnyAsync(i => i.Name == name, cancellationToken);
        }
    }
}
