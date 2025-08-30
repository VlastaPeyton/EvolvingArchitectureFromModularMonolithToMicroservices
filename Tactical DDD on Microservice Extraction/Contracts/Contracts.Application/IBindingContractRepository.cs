
using Contracts.Domain;
using ErrorOr;

namespace Contracts.Application
{
    public interface IBindingContractRepository
    {
        Task<ErrorOr<BindingContract>> GetByIdAsync(Guid bindingContractId, CancellationToken cancellationToken);
        Task AddAsync(BindingContract bindingContract, CancellationToken cancellationToken);
        Task CommitAsync(CancellationToken cancellationToken);
    }
}
