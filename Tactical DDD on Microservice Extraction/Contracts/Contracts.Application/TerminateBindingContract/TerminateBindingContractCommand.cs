
using ErrorOr;
using MediatR;

namespace Contracts.Application.TerminateBindingContract
{
    public sealed record TerminateBindingContractCommand(Guid BindingContractId) : ICommand<ErrorOr<Unit>>; // Unit je void u MediatR
}
