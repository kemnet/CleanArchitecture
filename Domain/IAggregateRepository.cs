using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain
{
    public interface IAggregateRepository<TAggregateRoot>
    {
        Task<TAggregateRoot> Load(Guid id, CancellationToken cancellationToken = default);
        Task Save(TAggregateRoot aggregate);
    }
}