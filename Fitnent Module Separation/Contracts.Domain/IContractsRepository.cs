using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Domain
{
    public interface IContractsRepository
    {
        Task<Contract?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Contract?> GetPreviousForCustomerAsync(Guid customerId, CancellationToken cancellationToken);
        Task AddAsync(Contract contract, CancellationToken cancellationToken);
        Task CommitAsync(CancellationToken cancellationToken);
    }
}
