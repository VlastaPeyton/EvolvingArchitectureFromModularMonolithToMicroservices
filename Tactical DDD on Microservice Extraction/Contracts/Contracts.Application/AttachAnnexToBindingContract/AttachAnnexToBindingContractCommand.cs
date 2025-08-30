
using ErrorOr;

namespace Contracts.Application.AttachAnnexToBindingContract
{
    public record AttachAnnexToBindingContractCommand(Guid BindingContractId, DateTimeOffset ValidFrom) : ICommand<ErrorOr<Guid>>;
    
}
