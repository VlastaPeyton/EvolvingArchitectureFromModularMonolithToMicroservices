

using Common.Domain;

namespace Contracts.Domain.SignContract
{
    public record BindingContractStartedDomainEvent(Guid Id, DateTimeOffset BindingFrom, DateTimeOffset? ExpiringAt, DateTime OccurredAt) : IDomainEvent
    {
        // Id, OccuredAt mora jer implementira IDomainEvent

        public static BindingContractStartedDomainEvent Raise(DateTimeOffset bindingFrom, DateTimeOffset? expiringAt)
        {
            return new BindingContractStartedDomainEvent(Guid.NewGuid(), bindingFrom, expiringAt, DateTime.UtcNow);
        }
    }
    
}
