using Kalakobana.Domain.Countries;
using Kalakobana.Domain.Names;
using Kalakobana.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Infrastructure.Repositories.FirstNames
{
    public class FirstNameRepository : IFirstNameRepository
    {
        private readonly IBaseRepository<FirstName> _firstNameRepository;

        public FirstNameRepository(IBaseRepository<FirstName> firstNameRepository)
        {
            _firstNameRepository = firstNameRepository;
        }

        public async Task<int> CreateAsync(CancellationToken cancellationToken, FirstName firstName)
        {
            await _firstNameRepository.AddAsync(firstName, cancellationToken);
            await _firstNameRepository.SaveChangesAsync(cancellationToken);
            return firstName.Id;
        }
        public async Task<bool> UpdateAsync(CancellationToken cancellationToken, string name, string newName)
        {
            var entity = await _firstNameRepository.Table.FirstOrDefaultAsync(i => i.Name == name);
            if (entity == null)
                throw new Exception();
            entity.Name = newName;
            _firstNameRepository.Update(entity, cancellationToken);
            return await _firstNameRepository.SaveChangesAsync(cancellationToken);
        }
        public async Task<bool> DeleteAsync(CancellationToken cancellationToken, string name)
        {
            var entity = await _firstNameRepository.Table.SingleOrDefaultAsync(i => i.Name == name);
            if (entity == null)
                throw new Exception();
            await _firstNameRepository.RemoveAsync(cancellationToken, entity.Id);
            return await _firstNameRepository.SaveChangesAsync(cancellationToken);
        }
        public async Task<bool> Exists(CancellationToken cancellationToken, string name)
        {
            return await _firstNameRepository.AnyAsync(i => i.Name == name, cancellationToken);
        }
    }
}
