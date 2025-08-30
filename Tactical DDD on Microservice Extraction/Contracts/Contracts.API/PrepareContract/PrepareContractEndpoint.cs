
using Common.API.ErrorHandling.Problems;
using Common.API.Validations;
using Contracts.Application;
using ErrorOr;
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
                
                return await contractsModule.ExecuteCommandAsync(command, cancellationToken)
                                            .Match(contractId => Results.Created($"api/contracts/{contractId}", contractId), errors => errors.ToProblem()); // Automatski aktivira SignContractCommandHandler jer je command=PrepareContractCommand


            }).ValidateRequest<PrepareContractRequestValidator>(); // U Common.sln objasnjeno u RequestValidationApiFilter kako automatski zna da pozove PrepareContractRequestValidator
        }
    }
}
