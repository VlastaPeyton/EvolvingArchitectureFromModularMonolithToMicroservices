using InitialArchitecture.Common.Events;
using InitialArchitecture.Common.Events.EventBus;
using InitialArchitecture.Offers.Data;
using InitialArchitecture.Offers.Data.Database;
using InitialArchitecture.Passes.MarkPassAsExpired.Events;
using MediatR;

namespace InitialArchitecture.Offers.PrepareOffer
{
    // Povezano sa Passes module kada clanaira istekne da se automatski publish OfferPrepareEvent i da se clientu posalje novi Offer
    internal sealed class PassExpiredEventHandler(IEventBus eventBus, OffersDbContext dbContext, TimeProvider timeProvider) : IIntegrationEventHandler<PassExpiredEvent>
    {   // U Common.Events.InMemoryEventBusModule je IEventBus registrovan kao InMemoryEventBus 
        // Koristim TimeProvider iako je to isto kao DateTimeOffset, ali ovo se moze lakse testirati nego DateTimeOffset

        public async Task Handle(PassExpiredEvent @event, CancellationToken cancellationToken)
        {   // PassExpiredEvent je iz Passes module 
            var nowDate = timeProvider.GetUtcNow(); // Ovo je u Common.Clock folderu u DI ubaceno, jer mora

            var offer = Offer.PrepareStandardPassExtension(@event.CustomerId, nowDate);

            dbContext.Offers.Add(offer); 
            await dbContext.SaveChangesAsync(); // Zbog Change Tracker ovo ce se u bazu postaviti

            var offerPreparedEvent = OfferPrepareEvent.Create(offer.Id, offer.CustomerId, timeProvider.GetUtcNow());

            await eventBus.PublishAsync(offerPreparedEvent, cancellationToken); // Event Handler za ovo se autoamtski aktivira kad ovde MediatR publish OfferPreparedEvent
        }
    }
}
