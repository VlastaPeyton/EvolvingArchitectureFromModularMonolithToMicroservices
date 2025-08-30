

using Common.API.ErrorHandling.Problems;
using Common.API.Validations;
using Contracts.Application;
using ErrorOr;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Contracts.API.AttachAnnexToBindingContract
{
    internal static class AttachAnnexToBindingContractEndpoint
    {
        public static void MapAttachAnnexToBindingContractEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPost("api/contracts", async (Guid id, AttachAnnexToBindingContractRequest request, IContractsModule contractsModule, CancellationToken cancellationToken) =>
            {
                var command = request.ToCommand(id);

                return contractsModule.ExecuteCommandAsync(command, cancellationToken)
                                      .Match(annexId => Results.Created($"api/contracts/{id}/{annexId}", annexId), errors => errors.ToProblem());
            }).ValidateRequest<AttachAnnexToBindingContractRequestValidator>();
        }
    }
}
