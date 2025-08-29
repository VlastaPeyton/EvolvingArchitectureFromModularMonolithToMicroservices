
using Contracts.IntegrationEvents;
using MassTransit;
using Passes.DataAccess;
using Passes.DataAccess.Database;

namespace Passes.API.RegisterPass
{
    public sealed class ContractSignedEventConsumer(PassesDbContext dbContext, TimeProvider timeProvider) : IConsumer<ContractSignedIntegrationEvent>
    {
        // Mora metoda zbog interface, jer ovako primam event preko MassTransit + RabbitMQ (Message Broker)
        // Consume se automatski aktivira kada Message Broker primi ContractSignedEvent iz Contracts.sln jer ContractSignedEventConsumer je Subscribed na to (namesteno u Passes.EventBus) + definisan OutboxExtension.cs
        public async Task Consume(ConsumeContext<ContractSignedIntegrationEvent> context)
        {
            var @event = context.Message; // Uzeo integration event iz RabbitMQ koji je Passes poslao u RabbitMQ
            var pass = Pass.Register(@event.ContractCustomerId, @event.SignedAt, @event.ExpireAt);
            await dbContext.Passes.AddAsync(pass, context.CancellationToken);
            await dbContext.SaveChangesAsync(context.CancellationToken);

            var passRegisteredIntegrationEvent = PassRegisteredIntegrationEvent.Create(pass.Id, timeProvider.GetUtcNow());
            await context.Publish(passRegisteredIntegrationEvent, context.CancellationToken); // Salje PassRegisteredIntegrationEvent u RabbitMQ
        }
    }
}
