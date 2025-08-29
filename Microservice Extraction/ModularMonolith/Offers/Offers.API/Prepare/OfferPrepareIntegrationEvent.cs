
using Common.Infrastructure.Events;

namespace Offers.API.Prepare
{    // Ne implementiram IIntegrationEvent jer to je sluzilo kada sam imao sve u Modular Monolith pa je MediatR sluzio da prenosi domain i integration events, a sad integration event prenosim MessageBroker

    internal record OfferPrepareIntegrationEvent(Guid Id, Guid OfferId, Guid CustomerId, DateTimeOffset OccurredDateTime) 
    {
        internal static OfferPrepareIntegrationEvent Create(Guid offerId, Guid customerId, DateTimeOffset occurredAt)
        {
            return new OfferPrepareIntegrationEvent(Guid.NewGuid(), offerId, customerId, occurredAt);
        }
    }
}
