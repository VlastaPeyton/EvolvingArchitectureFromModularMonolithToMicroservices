using InitialArchitecture.Passes.GetAllPasses;
using InitialArchitecture.Passes.MarkPassAsExpired;

namespace InitialArchitecture.Passes
{
    internal static class PassesEndpointsExtensions
    {
        public static void MapPasses(this IEndpointRouteBuilder app)
        {   // Jedina dva Endpointa koja imam za Passes
            app.MapGetAllPasses();
            app.MapMarkPassAsExpired();
        }
    }
}
