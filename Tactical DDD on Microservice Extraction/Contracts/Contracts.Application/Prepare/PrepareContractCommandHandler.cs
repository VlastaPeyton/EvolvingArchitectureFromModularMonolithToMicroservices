
using Contracts.Domain;
using MediatR;

namespace Contracts.Application.Prepare
{   
    // Guid, jer PrepareContractCommand : ICommand<Guid>, a ICommand<Guid>:IRequest<Guid>, pa Hadle mora da vrati Guid type
    internal sealed class PrepareContractCommandHandler(IContractRepository contractsRepository) : IRequestHandler<PrepareContractCommand, Guid> 
    {   // IContractsRepository bice registrovan kao ContractsRepository u Infrastructure 

        // Mora Handle zbog interface. Automatski se pozove kad PrepareContractEndpoint aktivira ExecuteCommandAsync
        public async Task<Guid> Handle(PrepareContractCommand command, CancellationToken cancellationToken)
        {
            var previousContract = await contractsRepository.GetPreviousForCustomerAsync(command.CustomerId, cancellationToken);
            var contract = Contract.Prepare(command.CustomerId, command.CustomerAge, command.CustomerHeight, command.PreparedAt, previousContract?.IsSigned);

            await contractsRepository.AddAsync(contract, cancellationToken);

            return contract.Id; // Guid 
        }
    }
}
