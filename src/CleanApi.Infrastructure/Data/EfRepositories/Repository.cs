using System.Threading.Tasks;
using CleanApi.Domain.Common;

namespace CleanApi.Infrastructure.Data.EfRepositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity: Entity where TKey:TypedIdValueBase
    {
        private readonly CleanApiContext _context;
        public Repository(CleanApiContext context)
        {
            _context = context;
        }
        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _context.FindAsync<TEntity>(id);
        }

        public async Task AddAsync(TEntity item)
        {
            await _context.AddAsync(item);
        }
    }
}