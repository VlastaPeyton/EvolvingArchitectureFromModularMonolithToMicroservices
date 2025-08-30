

using ErrorOr;
using MediatR;

namespace Contracts.Application.TerminateBindingContract
{
    internal sealed class TerminateBindingContractCommandHandler(IBindingContractRepository bindingContractRepository, TimeProvider timeProvider): IRequestHandler<TerminateBindingContractCommand, ErrorOr<Unit>>
    {
        public async Task<ErrorOr<Unit>> Handle(TerminateBindingContractCommand command, CancellationToken cancellationToken)
        {
            return await bindingContractRepository.GetByIdAsync(command.BindingContractId, cancellationToken)
                                                  .ThenAsync(bindingContract => bindingContract.Terminate(timeProvider.GetUtcNow())
                                                        .ThenAsync(async _ =>
                                                        {
                                                            await bindingContractRepository.CommitAsync(cancellationToken);

                                                            return Unit.Value;
                                                        }));
                                                  
        }
    }
}
