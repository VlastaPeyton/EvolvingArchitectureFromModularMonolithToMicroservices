

using Common.Infrastructure.Events;

namespace Passes.API
{         // Ne implementiram IIntegrationEvent jer to je sluzilo kada sam imao sve u Modular Monolith pa je MediatR sluzio da prenosi domain i integration events, a sad integration event prenosim MessageBroker

    public record PassExpiredIntegrationEvent(Guid Id, Guid PassId, Guid CustomerId, DateTimeOffset OccurredDateTime) 
    {
        public static PassExpiredIntegrationEvent Create(Guid passId, Guid customerId, DateTimeOffset occurredAt)
        {
            return new PassExpiredIntegrationEvent(Guid.NewGuid(), passId, customerId, occurredAt);
        }
    }
}
