
namespace Contracts.Application.Sign
{
    public record SignContractCommand(Guid Id, DateTimeOffset SignedAt) : ICommand;
}
