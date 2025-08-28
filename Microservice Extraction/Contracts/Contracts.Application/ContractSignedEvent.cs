
namespace Contracts.Application
{   
    // Ovo je Domain Event i zato je u Application layer
    public record ContractSignedEvent(Guid Id, Guid ContractId, Guid ContractCustomerId, DateTimeOffset SignedAt, DateTimeOffset ExpireAt, DateTimeOffset OccurredDateTime)
    {
        public static ContractSignedEvent Create(Guid contractId, Guid contractCustomerId, DateTimeOffset signedAt, DateTimeOffset expireAt, DateTimeOffset occurredAt)
        {
            return new ContractSignedEvent(Guid.NewGuid(), contractId, contractCustomerId, signedAt, expireAt, occurredAt);
        }
    }
}
