
using Common.Domain;

namespace Contracts.Domain.PrepareContract
{
    public record ContractPreparedDomainEvent(Guid Id, Guid CustomerId, DateTimeOffset PreparedAt, DateTime OccurredAt) : IDomainEvent
    { // Id i OccurredAt moraju zbog IDomainEvent

        public static ContractPreparedDomainEvent Raise(Guid customerId, DateTimeOffset preparedAt)
        {
            return new ContractPreparedDomainEvent(Guid.NewGuid(), customerId, preparedAt, DateTime.UtcNow);
        }
    }
}
