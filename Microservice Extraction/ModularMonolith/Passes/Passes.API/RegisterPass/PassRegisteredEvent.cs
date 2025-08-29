
using Common.Infrastructure.Events;

namespace Passes.API.RegisterPass
{
    internal record PassRegisteredIntegrationEvent(Guid Id, Guid PassId, DateTimeOffset OccurredDateTime) : IIntegrationEvent
    {
        public static PassRegisteredIntegrationEvent Create(Guid passId, DateTimeOffset occurredAt)
        {
            return new PassRegisteredIntegrationEvent(Guid.NewGuid(), passId, occurredAt);
        }
    }
}
