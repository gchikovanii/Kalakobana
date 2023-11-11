using System.Linq.Expressions;

namespace Kalakobana.Infrastructure.Repositories.Base
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> Table { get; }
        Task AddAsync(T entity, CancellationToken token);
        void Update(T entity, CancellationToken token);  
        Task RemoveAsync(CancellationToken token,params object[] key);
        Task<bool> AnyAsync(Expression<Func<T,bool>> predicate, CancellationToken token);
        Task<bool> SaveChangesAsync(CancellationToken token);

    }
}
