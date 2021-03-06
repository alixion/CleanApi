using System.Threading;
using System.Threading.Tasks;
using CleanApi.Domain.Common;

namespace CleanApi.Infrastructure.Data.EfRepositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly CleanApiContext _context;

        public UnitOfWork(CleanApiContext context)
        {
            _context = context;
        }
        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            //await this._domainEventsDispatcher.DispatchEventsAsync();
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}