using Common.API.ErrorHandling;
using Common.Infrastructure.Events.EventBus;
using Contracts.Application.IntegrationEvents;
using Contracts.Domain;
using MediatR;

namespace Contracts.Application.Sign
{

    public class SignContractCommandHandler(IContractsRepository contractsRepository,
                                            TimeProvider timeProvider,
                                            IEventBus eventBus) : IRequestHandler<SignContractCommand>
    {
        // Vraca void i zato nije imao drugi tip u IRequestHandler 
        // Aktivira se automatski kada u SignContractEndpoint se pozove ExecuteCommandAsync

        public async Task Handle(SignContractCommand command, CancellationToken cancellationToken)
        {
            var contract = await contractsRepository.GetByIdAsync(command.Id, cancellationToken) ?? throw new ResourceNotFoundException(command.Id);

            var now = timeProvider.GetUtcNow();

            contract.Sign(command.SignedAt, now);
            await contractsRepository.CommitAsync(cancellationToken); // Ovde nemamo dbContext jer je ovo Handler, pa da moze SaveChangesAsync i zato ova metoda postoji

            var @event = ContractSignedEvent.Create(contract.Id, contract.CustomerId, contract.SignedAt!.Value, contract.ExpiringAt!.Value, timeProvider.GetUtcNow());
            await eventBus.PublishAsync(@event, cancellationToken);

        }
    }
}
