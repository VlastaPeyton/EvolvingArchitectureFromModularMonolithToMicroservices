

using Common.API.ErrorHandling.Problems;
using Common.API.Validations;
using Contracts.Application;
using Contracts.Application.TerminateBindingContract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Contracts.API.TerminateContract
{
    internal static class TerminateContractEndpoint
    {
        public static void MapTerminateContractEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPatch("api/contracts/{id}", async (Guid id, IContractsModule contractsModule, CancellationToken cancellationToken) =>
            {
                var command = new TerminateBindingContractCommand(id);
                var result = await contractsModule.ExecuteCommandAsync(command, cancellationToken);
                var response = result.Match(_ => Results.NoContent(), errors => errors.ToProblem());
                return response;

            }); // Nema ValidateRequest ,jer nema Request 
        }
    }
}
