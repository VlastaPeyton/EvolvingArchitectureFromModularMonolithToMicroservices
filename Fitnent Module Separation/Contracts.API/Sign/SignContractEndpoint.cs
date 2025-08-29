using Common.API.Validation;
using Contracts.Application;

namespace Contracts.API.Sign
{
    internal static class SignContractEndpoint
    {
        internal static void MapSignContract(this IEndpointRouteBuilder app)
        {
            app.MapPatch("api/contracts", async (Guid id, SignContractRequest request, IContractsModule contractsModule, CancellationToken cancellationToken) =>
            {
                var command = request.ToCommand(id);

                await contractsModule.ExecuteCommandAsync(command, cancellationToken); // Aktivira se automatski SignContractCommandHandler zbog command tipa

                return Results.NoContent();

            }).ValidateRequest<SignContractRequestValidator>();
        }
    }
}
