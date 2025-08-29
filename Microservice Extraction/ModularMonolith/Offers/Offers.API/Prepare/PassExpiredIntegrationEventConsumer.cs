using MassTransit;
using Offers.DataAccess;
using Offers.DataAccess.Database;
using Passes.API;

namespace Offers.API.Prepare
{
    internal sealed class PassExpiredIntegrationEventConsumer(IPublishEndpoint eventBus, OffersDbContext dbContext, TimeProvider timeProvider) : IConsumer<PassExpiredIntegrationEvent>
    {
        // Mora metoda zbog interface jer ovako primam integration event preko RabbitMQ + MassTransit
        // Consume se automatski aktivira kada Message Broker primi PassExpiredIntegrationEvent jer PassExpiredIntegrationEventConsumer je Subscribed na to (namesteno u  Contracts.Infrastructure.EventBus)
        public async Task Consume(ConsumeContext<PassExpiredIntegrationEvent> context)
        {
            var @event = context.Message; // Uzeo integration event iz RabbitMQ koji je Passes poslao u RabbitMQ
            var offer = Offer.PrepareStandardPassExtension(@event.CustomerId, timeProvider.GetUtcNow());
            dbContext.Offers.Add(offer);
            await dbContext.SaveChangesAsync(context.CancellationToken);

            var offerPreparedIntegrationEvent = OfferPrepareIntegrationEvent.Create(offer.Id, offer.CustomerId, timeProvider.GetUtcNow());
            await eventBus.Publish(offerPreparedIntegrationEvent, context.CancellationToken); // Salje OfferPrepareIntegrationEvent u RabbitMQ

        }
    }
}
