using Kalakobana.Domain.LastNames;
using Kalakobana.Domain.Names;
using Kalakobana.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Infrastructure.Repositories.LastNames
{
    public class LastNameRepository : ILastNameRepository
    {
        private readonly IBaseRepository<LastName> _lastNameRepository;

        public LastNameRepository(IBaseRepository<LastName> lastNameRepository)
        {
            _lastNameRepository = lastNameRepository;
        }

        public async Task CreateAsync(CancellationToken cancellationToken, LastName lastName)
        {
            await _lastNameRepository.AddAsync(lastName, cancellationToken);
        }
        public async Task UpdateAsync(CancellationToken cancellationToken, string name, string newName)
        {
            var entity = await _lastNameRepository.Table.FirstOrDefaultAsync(i => i.Name == name);
            if (entity == null)
                throw new Exception();
            entity.Name = newName;
            _lastNameRepository.Update(entity, cancellationToken);
        }
        public async Task DeleteAsync(CancellationToken cancellationToken, string name)
        {
            var entity = await _lastNameRepository.Table.SingleOrDefaultAsync(i => i.Name == name);
            if (entity == null)
                throw new Exception();
            await _lastNameRepository.RemoveAsync(cancellationToken, entity.Id);
        }
        public async Task<bool> Exists(CancellationToken cancellationToken, string name)
        {
            return await _lastNameRepository.AnyAsync(i => i.Name == name, cancellationToken);
        }
    }
}
