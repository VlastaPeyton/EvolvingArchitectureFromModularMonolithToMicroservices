using Common.Infrastructure.Events;

namespace Offers.API.Prepare
{
    internal record OfferPrepareIntegrationEvent(Guid Id, Guid OfferId, Guid CustomerId, DateTimeOffset OccurredDateTime) : IIntegrationEvent
    {
        internal static OfferPrepareIntegrationEvent Create(Guid offerId, Guid customerId, DateTimeOffset occurredAt)
        {
            return new OfferPrepareIntegrationEvent(Guid.NewGuid(), offerId, customerId, occurredAt);
        }
    }

}
