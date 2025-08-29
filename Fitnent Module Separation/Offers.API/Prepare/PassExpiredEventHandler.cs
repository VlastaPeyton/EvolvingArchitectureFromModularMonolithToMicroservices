using Common.Infrastructure.Events;
using Common.Infrastructure.Events.EventBus;
using Offers.DataAccess;
using Offers.DataAccess.Database;
using Passes.API.IntegrationEvents;

namespace Offers.API.Prepare
{   
    internal sealed class PassExpiredEventHandler(IEventBus eventBus, OffersDbContext dbContext, TimeProvider timeProvider) : IIntegrationEventHandler<PassExpiredEvent>
    {
        // Automatski se aktivira Handle kada mediator.PublishAsync PassExpiredEvent
        public async Task Handle(PassExpiredEvent @event, CancellationToken cancellationToken)
        {
            var nowDate = timeProvider.GetUtcNow();
            var offer = Offer.PrepareStandardPassExtension(@event.CustomerId, nowDate);
            await dbContext.Offers.AddAsync(offer, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            var offerPreparedEvent = OfferPrepareEvent.Create(offer.Id, offer.CustomerId, timeProvider.GetUtcNow());
            await eventBus.PublishAsync(offerPreparedEvent, cancellationToken);
        }
    }
}
