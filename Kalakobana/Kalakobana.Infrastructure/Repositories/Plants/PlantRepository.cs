using Kalakobana.Domain.Cities;
using Kalakobana.Domain.Plants;
using Kalakobana.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Infrastructure.Repositories.Plants
{
    public class PlantRepository : IPlantRepository
    {
        private readonly IBaseRepository<Plant> _plantRepository;

        public PlantRepository(IBaseRepository<Plant> plantRepository)
        {
            _plantRepository = plantRepository;
        }

        public async Task<int> CreateAsync(CancellationToken cancellationToken, Plant plant)
        {
            await _plantRepository.AddAsync(plant, cancellationToken);
            return plant.Id;
        }
        public async Task UpdateAsync(CancellationToken cancellationToken, string name, string newName)
        {
            var entity = await _plantRepository.Table.FirstOrDefaultAsync(i => i.Name == name);
            if (entity == null)
                throw new Exception();
            entity.Name = newName;
            _plantRepository.Update(entity, cancellationToken);
        }
        public async Task DeleteAsync(CancellationToken cancellationToken, string name)
        {
            var entity = await _plantRepository.Table.SingleOrDefaultAsync(i => i.Name == name);
            if (entity == null)
                throw new Exception();
            await _plantRepository.RemoveAsync(cancellationToken, entity.Id);
        }
        public async Task<bool> Exists(CancellationToken cancellationToken, string name)
        {
            return await _plantRepository.AnyAsync(i => i.Name == name, cancellationToken);
        }
    }
}

