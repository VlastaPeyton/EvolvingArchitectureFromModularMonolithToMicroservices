using InitialArchitecture.Common.Events;
using InitialArchitecture.Common.Events.EventBus;
using InitialArchitecture.Contracts.SignContract.Events;
using InitialArchitecture.Passes.Data;
using InitialArchitecture.Passes.Data.Database;
using InitialArchitecture.Passes.RegisterPass.Events;
using MediatR;

namespace InitialArchitecture.Passes.RegisterPass
{   
    // Automatksi se aktivira kada MediatR Publish ContractSignedEvent u Contracts.SignContract.SignContractEndpoint, zato sto je nasledio IIntegrationHandler(:INotificationHandler)
    internal sealed class ContractSignedEventHandler(PassesDbContext dbContext, IEventBus eventBus) : IIntegrationEventHandler<ContractSignedEvent>
    {
       public async Task Handle(ContractSignedEvent @event, CancellationToken cancellationToken)
       {
            var pass = Pass.Register(@event.ContractCustomerId, @event.SignedAt, @event.ExpireAt);
            await dbContext.AddAsync(pass, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            var passRegisteredEvent = PassRegisteredEvent.Create(pass.Id);
            // Publish PassRegisteredEvent nakon sto je Contract Signed i kad je taj pass uneo u bazu
            await eventBus.PublishAsync(passRegisteredEvent, cancellationToken); //
       }
    }
}
