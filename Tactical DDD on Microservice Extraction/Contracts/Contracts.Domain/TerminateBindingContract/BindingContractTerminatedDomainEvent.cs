

using Common.Domain;

namespace Contracts.Domain.TerminateBindingContract
{
    public record BindingContractTerminatedDomainEvent(Guid Id, DateTimeOffset TerminatedAt, DateTime OccurredAt) : IDomainEvent
    { // Mora Id i OccurredAt zbog IDomainEvent

        public static BindingContractTerminatedDomainEvent Raise(DateTimeOffset terminatedAt)
        {
            return new BindingContractTerminatedDomainEvent(Guid.NewGuid(), terminatedAt, DateTime.UtcNow);
        }
    }
}
