﻿

using Common.API.ErrorHandling;
using Contracts.Domain;
using MassTransit;
using MediatR;

namespace Contracts.Application.Sign
{
    // No return type u IRequestHandler, pa Handle mora da vrati void 
    internal sealed class SignContractCommandHandler(IContractsRepository contractsRepository, 
                                                     TimeProvider timeProvider,
                                                     IPublishEndpoint publishEndpoint) : IRequestHandler<SignContractCommand>
    {
        // Mora Handle zbog interface. Automatski se pozove kada 
        public async Task Handle(SignContractCommand command, CancellationToken cancellationToken)
        {
            var contract = await contractsRepository.GetByIdAsync(command.Id, cancellationToken) ?? throw new ResourceNotFoundException(command.Id); 
            // Svaki Common solution project je napravljen kao NuGet package i zato ovde ResourceNotFoundException 

            contract.Sign(command.SignedAt, timeProvider.GetLocalNow());

            await contractsRepository.CommitAsync(cancellationToken);

            var @event = ContractSignedEvent.Create(contract.Id, contract.CustomerId, contract.SignedAt!.Value, contract.ExpiringAt!.Value, timeProvider.GetLocalNow());
            // ContractSignedEvent je IntegrationEvent jer ga odavde Publish to RabbitMQ 
            await publishEndpoint.Publish(@event, cancellationToken);

        }
    }
}
