using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using registrationapp_core.Repositories;

namespace registrationapp_data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        protected readonly IMapper _mapper;

        public Repository(DbContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await Context.Set<T>().AddAsync(entity, cancellationToken);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await Context.Set<T>().AddRangeAsync(entities, cancellationToken);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken) != null;
        }

        public async Task<IEnumerable<TResult>> FindAsync<TResult>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().Where(predicate).ProjectTo<TResult>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().ProjectTo<TResult>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }
    }
}