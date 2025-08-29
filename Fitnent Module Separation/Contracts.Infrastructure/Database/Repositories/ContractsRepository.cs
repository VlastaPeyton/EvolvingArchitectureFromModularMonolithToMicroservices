using Contracts.Domain;
using Microsoft.EntityFrameworkCore;

namespace Contracts.Infrastructure.Database.Repositories
{
    internal sealed class ContractsRepository(ContractsDbContext dbContext) : IContractsRepository
    {
        public async Task AddAsync(Contract contract, CancellationToken cancellationToken)
        {
            await dbContext.AddAsync(contract, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Contract?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await dbContext.Contracts.FindAsync([id], cancellationToken);
        }

        public async Task<Contract?> GetPreviousForCustomerAsync(Guid customerId, CancellationToken cancellationToken)
        {
            return await dbContext.Contracts.OrderByDescending(contract => contract.PreparedAt).SingleOrDefaultAsync(contract => contract.CustomerId == customerId, cancellationToken);
        }
    }
}
