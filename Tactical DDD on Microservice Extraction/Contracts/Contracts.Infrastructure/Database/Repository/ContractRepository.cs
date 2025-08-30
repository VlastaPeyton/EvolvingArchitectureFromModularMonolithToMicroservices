

using Contracts.Application;
using Contracts.Domain;
using Contracts.Domain.CustomId;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace Contracts.Infrastructure.Database.Repository
{
    internal sealed class ContractRepository(ContractsDbContext dbContext) : IContractRepository
    {
        public async Task AddAsync(Contract contract, CancellationToken cancellationToken)
        {
            await dbContext.Contracts.AddAsync(contract, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<ErrorOr<Contract>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var contract =  await dbContext.Contracts.FindAsync([new ContractId(id)], cancellationToken); // ContractId definisan u Configurations da EF Core zna kako da ga cita i upisuje u bazu obzirom da je cutom type

            return contract is not null ? contract : Error.NotFound(nameof(Contract), $"Contract with id '{id}' not found");
        }

        public async Task<Contract?> GetPreviousForCustomerAsync(Guid customerId, CancellationToken cancellationToken)
        {
            return await dbContext.Contracts.OrderByDescending(contract => contract.PreparedAt).SingleOrDefaultAsync(contract => contract.CustomerId == customerId, cancellationToken);
        }
    }
}
