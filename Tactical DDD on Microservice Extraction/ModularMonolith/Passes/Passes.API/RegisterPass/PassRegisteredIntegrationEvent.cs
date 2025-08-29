
using Common.Infrastructure.Events;

namespace Passes.API.RegisterPass
{   
    // Ne implementiram IIntegrationEvent jer to je sluzilo kada sam imao sve u Modular Monolith pa je MediatR sluzio da prenosi domain i integration events, a sad integration event prenosim MessageBroker
    internal record PassRegisteredIntegrationEvent(Guid Id, Guid PassId, DateTimeOffset OccurredDateTime) 
    {
        public static PassRegisteredIntegrationEvent Create(Guid passId, DateTimeOffset occurredAt)
        {
            return new PassRegisteredIntegrationEvent(Guid.NewGuid(), passId, occurredAt);
        }
    }
}
