using Common.Infrastructure.Events;
using Common.Infrastructure.Events.EventBus;
using Contracts.Application.IntegrationEvents;
using Passes.DataAccess;
using Passes.DataAccess.Database;

namespace Passes.API.RegisterPass
{
    internal sealed class ContractSignedEventHandler(PassesDbContext dbContext, TimeProvider timeProvider, IEventBus eventBus) : IIntegrationEventHandler<ContractSignedEvent>
    {
        // Automatski se aktivira kada MediatR Publish ContractSignedEvent u SignContractEventHandler
        public async Task Handle(ContractSignedEvent @event, CancellationToken cancellationToken)
        {
            var pass = Pass.Register(@event.ContractCustomerId, @event.SignedAt, @event.ExpireAt);
            await dbContext.Passes.AddAsync(pass, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            var passRegisteredEvent = PassRegisteredEvent.Create(pass.Id, timeProvider.GetUtcNow());
            await eventBus.PublishAsync(passRegisteredEvent, cancellationToken);
        }
    }
}
