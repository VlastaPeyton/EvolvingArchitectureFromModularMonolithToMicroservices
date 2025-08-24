using Common.API.Validation;
using Contracts.Application;

namespace Contracts.API.Prepare
{
    internal static class PrepareContractEndpoint
    {
        public static void MapPrepareContract(this IEndpointRouteBuilder app)
        {
            app.MapPost("api/contracts", async (PrepareContractRequest request, IContractsModule contractsModule, CancellationToken cancellationToken) =>
            { // U InitialArchitecture, ovde je bio DbContext, ali sad imam CQS pa moram to 

                var command = request.ToCommand();
                var contractId = await contractsModule.ExecuteCommandAsync(command, cancellationToken); // Automatski aktivira PrepareContractCommandHandler zbog command tipa

                return Results.Created($"/api/contracts/{contractId}", contractId);

            }).ValidateRequest<PrepareContractRequest>();
        }
    }
}
