

using Common.API.ErrorHandling;
using Contracts.IntegrationEvents;
using MassTransit;
using MediatR;

namespace Contracts.Application.Sign
{
    // No return type u IRequestHandler, pa Handle mora da vrati void 
    internal sealed class SignContractCommandHandler(IContractRepository contractsRepository, 
                                                     TimeProvider timeProvider,
                                                     IPublishEndpoint eventBus) : IRequestHandler<SignContractCommand>
    {
        // Mora Handle zbog interface. Automatski se pozove kada SignContractEndpoint uradi ExecuteCommandAsync
        public async Task Handle(SignContractCommand command, CancellationToken cancellationToken)
        {   // Prethodno ga je PrepareContractCommandHandler ubacio u bazu pa zato sad mogu da ga nadjem u bazi
            var contract = await contractsRepository.GetByIdAsync(command.Id, cancellationToken) ?? throw new ResourceNotFoundException(command.Id); 
            // Svaki Common solution project je napravljen kao NuGet package i zato ovde ResourceNotFoundException moze + u tom package ima ErrorHandlingExtension za ovo

            contract.Sign(command.SignedAt, timeProvider.GetLocalNow());

            await contractsRepository.CommitAsync(cancellationToken);

            var @event = ContractSignedEvent.Create(contract.Id, contract.CustomerId, contract.SignedAt!.Value, contract.ExpiringAt!.Value, timeProvider.GetLocalNow());
            // ContractSignedEvent je IntegrationEvent jer ga odavde Publish to RabbitMQ, ali ne implementira IIntegrationEvent jer to je za MediatR, a sad koristim RabbitMQ za integration event slanje
            await eventBus.Publish(@event, cancellationToken);

        }
    }
}
