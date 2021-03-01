using System.Threading;
using System.Threading.Tasks;

namespace CleanApi.Domain.Common
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}