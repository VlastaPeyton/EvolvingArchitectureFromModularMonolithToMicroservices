using Contracts.API.Prepare;
using Contracts.API.Sign;

namespace Contracts.API
{
    internal static class ContractsEndpoints
    {
        internal static void MapContracts(this IEndpointRouteBuilder app)
        {
            app.MapPrepareContract();
            app.MapSignContract();
        }
    }
}
