using Common.Infrastructure.Events;

namespace Passes.API.RegisterPass
{
    public record PassRegisteredEvent(Guid Id, Guid PassId, DateTimeOffset OccurredDateTime) : IIntegrationEvent
    {
        public static PassRegisteredEvent Create(Guid passId, DateTimeOffset occuredAt)
        {
            return new PassRegisteredEvent(Guid.NewGuid(), passId, occurredAt);
        }
    }
}
