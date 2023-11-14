using Kalakobana.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Kalakobana.Infrastructure.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly KalakobanaDbContext _context;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(KalakobanaDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public IQueryable<T> Table => _dbSet;

        public async Task AddAsync(T entity, CancellationToken token)
        {
            await _dbSet.AddAsync(entity,token);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken token)
        {
            return await _dbSet.AnyAsync(predicate,token);
        }

        public async Task RemoveAsync(CancellationToken token, params object[] key)
        {
            var entity = await _dbSet.FindAsync(key, token);
            _dbSet.Remove(entity);
        }
        public void Update(T entity, CancellationToken token)
        {
            if (entity == null)
                return;
            _dbSet.Update(entity);
        }
    }
}
