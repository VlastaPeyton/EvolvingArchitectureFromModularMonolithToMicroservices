using Passes.API.GetAllPasses;
using Passes.API.MarkPassAsExpired;

namespace Passes.API
{
    internal static class PassesEndpoint
    {
        internal static void MapPasses(this IEndpointRouteBuilder app)
        {
            app.MapMarkPassAsExpired();
            app.MapGetAllPasses();
        }
    }
}
