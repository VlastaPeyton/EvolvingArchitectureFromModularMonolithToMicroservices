
using Common.API.Validations;
using Contracts.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Contracts.API.Prepare
{
    internal static class PrepareContractEndpoint
    {
        public static void MapPrepareContractEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPost("api/contracts", async (PrepareContractRequest request, IContractsModule contractsModule, CancellationToken cancellationToken) =>
            {   // Pre nego sto Request udje u Endpoint, izvrsi se ValidateRequesst<SignContractRequestValidator>
                
                var command = request.ToCommand(); // Mapiram Request to Command 
                
                var contractId = await contractsModule.ExecuteCommandAsync(command, cancellationToken); // Automatski aktivira SignContractCommandHandler jer je command=PrepareContractCommand

                return Results.Created($"api/contracts/{contractId}", contractId);

            }).ValidateRequest<PrepareContractRequestValidator>(); // U Common.sln objasnjeno u RequestValidationApiFilter kako automatski zna da pozove PrepareContractRequestValidator
        }
    }
}
