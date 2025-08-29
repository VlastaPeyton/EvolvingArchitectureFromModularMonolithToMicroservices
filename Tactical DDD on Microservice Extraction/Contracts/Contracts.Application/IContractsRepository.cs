


using Contracts.Domain;

namespace Contracts.Application
{
    public interface IContractsRepository
    {
        Task<Contract?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Contract?> GetPreviousForCustomerAsync(Guid customerId, CancellationToken cancellationToken);
        Task AddAsync(Contract contract, CancellationToken cancellationToken);
        Task CommitAsync(CancellationToken cancellationToken);

    }
}
