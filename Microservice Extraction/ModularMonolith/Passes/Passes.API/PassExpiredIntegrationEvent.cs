

using Common.Infrastructure.Events;

namespace Passes.API
{   
    public record PassExpiredIntegrationEvent(Guid Id, Guid PassId, Guid CustomerId, DateTimeOffset OccurredDateTime) : IIntegrationEvent
    {
        public static PassExpiredIntegrationEvent Create(Guid passId, Guid customerId, DateTimeOffset occurredAt)
        {
            return new PassExpiredIntegrationEvent(Guid.NewGuid(), passId, customerId, occurredAt);
        }
    }
}
