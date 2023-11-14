using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Infrastructure.Units
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
