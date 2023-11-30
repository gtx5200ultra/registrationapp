using System.Linq.Expressions;

namespace registrationapp_core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<TResult>> GetAllAsync<TResult>(CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<TResult>> FindAsync<TResult>(Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default);
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
