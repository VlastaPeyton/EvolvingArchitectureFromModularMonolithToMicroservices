using Contracts.Application.Sign;

namespace Contracts.API.Sign
{
    internal record SignContractRequest(DateTimeOffset SignedAt)
    {
        internal SignContractCommand ToCommand(Guid id) =>
            new SignContractCommand(id, SignedAt);
    }
}
