
using Contracts.Domain;
using ErrorOr;
using MediatR;

namespace Contracts.Application.Prepare
{   
    // Guid, jer PrepareContractCommand : ICommand<Guid>, a ICommand<Guid>:IRequest<Guid>, pa Hadle mora da vrati Guid type
    internal sealed class PrepareContractCommandHandler(IContractRepository contractRepository) : IRequestHandler<PrepareContractCommand, ErrorOr<Guid>> 
    {   // IContractsRepository bice registrovan kao ContractsRepository u Infrastructure 

        // Mora Handle zbog interface. Automatski se pozove kad PrepareContractEndpoint aktivira ExecuteCommandAsync
        public async Task<ErrorOr<Guid>> Handle(PrepareContractCommand command, CancellationToken cancellationToken)
        {
            var previousContract = await contractRepository.GetPreviousForCustomerAsync(command.CustomerId, cancellationToken);
            return await Contract.Prepare(command.CustomerId, command.CustomerAge, command.CustomerHeight, command.PreparedAt, previousContract?.IsSigned)
                                   .ThenAsync(async contract =>
                                   {
                                       await contractRepository.AddAsync(contract, cancellationToken);
                                       await contractRepository.CommitAsync(cancellationToken);

                                       return contract.Id.Value;
                                   });


           
        }
    }
}
