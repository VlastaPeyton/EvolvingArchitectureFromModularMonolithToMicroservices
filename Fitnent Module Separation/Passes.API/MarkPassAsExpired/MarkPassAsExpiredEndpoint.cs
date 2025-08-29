using Common.Infrastructure.Events.EventBus;
using Passes.API.IntegrationEvents;
using Passes.DataAccess.Database;

namespace Passes.API.MarkPassAsExpired
{
    internal static class MarkPassAsExpiredEndpoint
    {
        public static void MapMarkPassAsExpired(this IEndpointRouteBuilder app)
        {
            app.MapPatch("/api/passes/", async (Guid id, PassesDbContext dbContext, TimeProvider timeProvider, IEventBus eventBus, CancellationToken ct) =>
            {
                var pass = await dbContext.Passes.FindAsync([id], ct);
                if (pass is null)
                    return Results.NotFound();

                var now = timeProvider.GetUtcNow();
                pass.MarkAsExpired(now);
                await dbContext.SaveChangesAsync(ct);

                var passExpiredEvent = PassExpiredEvent.Create(pass.Id, pass.CustomerId, timeProvider.GetUtcNow());
                await eventBus.PublishAsync(passExpiredEvent, ct);

                return Results.NoContent();
            });
        }
    }
}
