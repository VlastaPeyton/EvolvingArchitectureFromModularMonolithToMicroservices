namespace Contracts.Application.Prepare
{   
    // Command je obicno Record
    // PrepareContractCommandHandler vratice Guid nakon izvrsenja, zbog ICommand<Guid>
    public record PrepareContractCommand(Guid CustomerId, int CustomerAge, int CustomerHeight, DateTimeOffset PreparedAt) : ICommand<Guid>;
}
