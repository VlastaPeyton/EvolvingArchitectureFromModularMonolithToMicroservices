
using ErrorOr;

namespace Contracts.Application.Sign
{
    public record SignContractCommand(Guid Id, string Signature, DateTimeOffset SignedAt) : ICommand<ErrorOr<Guid>>;
}
