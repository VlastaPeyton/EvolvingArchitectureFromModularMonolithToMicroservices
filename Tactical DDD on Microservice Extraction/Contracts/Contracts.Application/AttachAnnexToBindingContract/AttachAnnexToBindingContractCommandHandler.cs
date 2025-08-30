

using ErrorOr;
using MediatR;

namespace Contracts.Application.AttachAnnexToBindingContract
{   
    internal sealed class AttachAnnexToBindingContractCommandHandler(IBindingContractRepository bindingContractRepository, TimeProvider timeProvider) : IRequestHandler<AttachAnnexToBindingContractCommand, ErrorOr<Guid>>
    {
        public async Task<ErrorOr<Guid>> Handle(AttachAnnexToBindingContractCommand command, CancellationToken cancellationToken)
        {
            return await bindingContractRepository.GetByIdAsync(command.BindingContractId, cancellationToken)
                                                  .ThenAsync(bindingContract => bindingContract.AttachAnnex(command.ValidFrom, timeProvider.GetUtcNow())
                                                      .ThenAsync(async annexId =>
                                                      {
                                                          await bindingContractRepository.CommitAsync(cancellationToken);
                                                          return annexId.Value;
                                                      }));
        }
    }
}
