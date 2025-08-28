
using Common.API.Validations;
using Contracts.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Contracts.API.Sign
{
    internal static class SignContractEndpoint
    {
        public static void MapSignContractEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPatch("api/contracts", async (Guid id, SignContractRequest request, IContractsModule contractsModule, CancellationToken cancellationToken) =>
            {   // Pre nego sto Request udje u Endpoint, izvrsi se ValidateRequesst<SignContractRequestValidator>
                
                var command = request.ToCommand(id); // Mapiram Request to Command 
                
                await contractsModule.ExecuteCommandAsync(command, cancellationToken); // Automatski aktivira SignContractCommandHandler jer je commandSignContractCommand

                return Results.NoContent();

            }).ValidateRequest<SignContractRequestValidator>(); // U Common.sln objasnjeno u RequestValidationApiFilter kako automatski zna da pozove SignContractRequestValidator
        }
    }
}
