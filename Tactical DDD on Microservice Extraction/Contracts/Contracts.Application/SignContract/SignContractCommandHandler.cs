

using Common.API.ErrorHandling;
using Contracts.Domain.SignContract.Signatures;
using Contracts.IntegrationEvents;
using ErrorOr;
using MassTransit;
using MediatR;

namespace Contracts.Application.Sign
{
    // No return type u IRequestHandler, pa Handle mora da vrati void 
    internal sealed class SignContractCommandHandler(IContractRepository contractRepository,
                                                     IBindingContractRepository bindingContractRepository,
                                                     TimeProvider timeProvider,
                                                     IPublishEndpoint eventBus) : IRequestHandler<SignContractCommand, ErrorOr<Guid>>
    {
        // Mora Handle zbog interface. Automatski se pozove kada SignContractEndpoint uradi ExecuteCommandAsync
        public async Task<ErrorOr<Guid>> Handle(SignContractCommand command, CancellationToken cancellationToken)
        {   // Prethodno ga je PrepareContractCommandHandler ubacio u bazu pa zato sad mogu da ga nadjem u bazi

            return await contractRepository.GetByIdAsync(command.Id, cancellationToken)
                                    .ThenAsync(async contract => await contract.Sign(Signature.From(command.SignedAt, command.Signature), timeProvider.GetUtcNow())
                                        .ThenAsync(async bindingContract =>
                                         {
                                             await bindingContractRepository.AddAsync(bindingContract, cancellationToken);
                                             await contractRepository.CommitAsync(cancellationToken);
                                             var contractSignedIntegrationEvent = ContractSignedIntegrationEvent.Create(contract.Id.Value, contract.CustomerId, contract.Signature!.Date, contract.ExpiringAt!.Value, timeProvider.GetLocalNow());
                                             await eventBus.Publish(contractSignedIntegrationEvent, cancellationToken);
                                             return bindingContract.Id.Value;
                                         }));
            


        }
    }
}
