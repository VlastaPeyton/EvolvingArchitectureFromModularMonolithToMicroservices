using Contracts.Application.Prepare;

namespace Contracts.API.Prepare
{
    internal record PrepareContractRequest(Guid CustomerId, int CustomerAge, int CustomerHeight, DateTimeOffset PreparedAt)
    {
        internal PrepareContractCommand ToCommand() => new PrepareContractCommand(CustomerId, CustomerAge, CustomerHeight, PreparedAt);
    }
}
