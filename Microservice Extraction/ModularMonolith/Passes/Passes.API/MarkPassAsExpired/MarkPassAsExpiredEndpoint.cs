
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Passes.DataAccess.Database;

namespace Passes.API.MarkPassAsExpired
{
    internal static class MarkPassAsExpiredEndpoint
    {   // 	<FrameworkReference Include="Microsoft.AspNetCore.App" /> mora u Passes.API.csproj kako bih u Class library mogao da koristim IEndpointRouteBuilder
        public static void MapMarkPassAsExpiredEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPatch("api/passes", async (Guid id, PassesDbContext dbContext, TimeProvider timeProvider, IPublishEndpoint eventBus, CancellationToken cancellationToken) =>
            {
                var pass = await dbContext.Passes.FindAsync([id], cancellationToken);
                if (pass is null)
                    return Results.NotFound();

                pass.MarkAsExpired(timeProvider.GetUtcNow());
                await dbContext.SaveChangesAsync(cancellationToken);

                var passExpiredEvent = PassExpiredIntegrationEvent.Create(pass.Id, pass.CustomerId, timeProvider.GetUtcNow());
                await eventBus.Publish(passExpiredEvent, cancellationToken);

                return Results.NoContent();
            }); // Nema ValidateRequest, jer Endpoint ne prima Request
        }
    }
}
