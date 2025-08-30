
using ErrorOr;

namespace Contracts.Application.Prepare
{
    public record PrepareContractCommand(Guid CustomerId, int CustomerAge, int CustomerHeight, DateTimeOffset PreparedAt) : ICommand<ErrorOr<Guid>>;
}
