namespace Contracts.Application.Sign
{
    public record SignContractCommand(Guid Id, DateTimeOffset SignedAt) : ICommand; // Nemamo generic ovde jer SignContractCommandHandler vratice void
}
