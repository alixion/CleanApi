using System.Threading.Tasks;

namespace CleanApi.Domain.Common
{
    public interface IRepository<TEntity, in TKey> where TEntity: Entity where TKey:TypedIdValueBase
    {
        Task<TEntity> GetByIdAsync(TKey id);
        Task AddAsync(TEntity item);
    }
}