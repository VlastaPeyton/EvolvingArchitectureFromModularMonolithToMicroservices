using InitialArchitecture.Common.Events;

namespace InitialArchitecture.Offers.PrepareOffer
{
    // Objasnjeno u Contracts
    internal record OfferPrepareEvent(Guid Id, 
                                       Guid OfferId, 
                                       Guid CustomerId, 
                                       DateTimeOffset OccuredDateTime) 
    : IIntegrationEvent
    {
        public static OfferPrepareEvent Create(Guid offerId, Guid offerCustomerId, DateTimeOffset occurredAt)
        {
            return new OfferPrepareEvent(Guid.NewGuid(), offerId, offerCustomerId, occurredAt);
        }
    }
}
