
using Contracts.Application.AttachAnnexToBindingContract;

namespace Contracts.API.AttachAnnexToBindingContract
{
    internal  record AttachAnnexToBindingContractRequest(DateTimeOffset ValidFrom)
    {
        internal AttachAnnexToBindingContractCommand ToCommand(Guid bindingContractId) =>
            new(bindingContractId, ValidFrom);
    }
}
