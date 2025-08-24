using Contracts.Domain;
using MediatR;

namespace Contracts.Application.Prepare
{   
    
    public class PrepareContractCommandHandler(IContractsRepository contractsRepository) : IRequestHandler<PrepareContractCommand, Guid>
    {  // Guid stoji jer ICommand<Guid> stoji u PrepareContractCommandHandler

        // Aktivira se automatski kada u PrepareContractEndpoint se pozove ExecuteCommandAsync
        public async Task<Guid> Handle(PrepareContractCommand command, CancellationToken cancellationToken)
        {
            var previousContract = await contractsRepository.GetPreviousForCustomerAsync(command.CustomerId, cancellationToken);

            var contract = Contract.Prepare(command.CustomerId, command.CustomerAge, command.CustomerHeight, command.PreparedAt, previousContract?.IsSigned);

            await contractsRepository.AddAsync(contract, cancellationToken);

            return contract.Id;
        }
    }

}
