

using Contracts.Application;
using Contracts.Domain;
using Contracts.Domain.CustomId;
using ErrorOr;

namespace Contracts.Infrastructure.Database.Repository
{
    internal class BindingContractRepository(ContractsDbContext dbContext) : IBindingContractRepository // IBindingContractRepository u Application layer ofc
    {
        public async Task AddAsync(BindingContract bindingContract, CancellationToken cancellationToken)
        {
            await dbContext.BindingContracts.AddAsync(bindingContract, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<ErrorOr<BindingContract>> GetByIdAsync(Guid bindingContractId, CancellationToken cancellationToken)
        {
            var bindingContract = await dbContext.BindingContracts.FindAsync([new BindingContractId(bindingContractId)], cancellationToken);  // U Configurations definisano kako db cita/upise ovaj custom type

            return bindingContract is null ? Error.NotFound(nameof(BindingContract), $"Binding contract with id {bindingContractId} not found") : bindingContract;
        }
    }
}
