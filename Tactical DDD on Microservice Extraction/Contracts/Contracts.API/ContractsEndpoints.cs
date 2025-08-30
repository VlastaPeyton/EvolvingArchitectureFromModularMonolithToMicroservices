

using Contracts.API.AttachAnnexToBindingContract;
using Contracts.API.Prepare;
using Contracts.API.Sign;
using Microsoft.AspNetCore.Routing;

namespace Contracts.API
{
    internal static class ContractsEndpoints
    {
        public static void MapContractsEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPrepareContractEndpoint();
            app.MapSignContractEndpoint();
            app.MapTerminateBindingContractEndpoint();
            app.MapAttachAnnexToBindingContractEndpoint();
        }
    }
}
