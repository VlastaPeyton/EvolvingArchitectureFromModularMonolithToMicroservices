using Common.Infrastructure.Events;

namespace Offers.API.Prepare
{
    internal sealed record OfferPrepareEvent(Guid Id, Guid OfferId, Guid CustomerId, DateTimeOffset OccurredDateTime) : IIntegrationEvent
    {
        internal static OfferPrepareEvent Create(Guid offerId, Guid customerId, DateTimeOffset occurredAt) =>
            new OfferPrepareEvent(Guid.NewGuid(), offerId, customerId, occurredAt);
    }
}
