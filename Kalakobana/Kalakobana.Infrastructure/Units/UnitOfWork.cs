using Kalakobana.Persistence.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Infrastructure.Units
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KalakobanaDbContext _kalakobanaDbContext;

        public UnitOfWork(KalakobanaDbContext kalakobanaDbContext)
        {
            _kalakobanaDbContext = kalakobanaDbContext;
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _kalakobanaDbContext.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
