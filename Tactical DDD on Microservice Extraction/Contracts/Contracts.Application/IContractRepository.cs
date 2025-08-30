


using Contracts.Domain;
using ErrorOr;

namespace Contracts.Application
{
    public interface IContractRepository
    {
        Task<ErrorOr<Contract>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Contract?> GetPreviousForCustomerAsync(Guid customerId, CancellationToken cancellationToken);
        Task AddAsync(Contract contract, CancellationToken cancellationToken);
        Task CommitAsync(CancellationToken cancellationToken);

    }
}
