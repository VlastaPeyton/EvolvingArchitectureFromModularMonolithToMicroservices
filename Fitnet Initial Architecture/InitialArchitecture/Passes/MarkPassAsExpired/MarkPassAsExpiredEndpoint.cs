using InitialArchitecture.Common.Events.EventBus;
using InitialArchitecture.Passes.Data.Database;
using InitialArchitecture.Passes.MarkPassAsExpired.Events;

namespace InitialArchitecture.Passes.MarkPassAsExpired
{
    internal static class MarkPassAsExpiredEndpoint
    {
       public static void MapMarkPassAsExpired(this IEndpointRouteBuilder app)
        {
            app.MapPatch("api/passes/{id}", async (Guid id, PassesDbContext dbContext, TimeProvider timeProvider, IEventBus eventBus, CancellationToken cancellationToken) =>
            {   // Ove argumente u Endpoint, RequestValidationApiFilter vidi kao Arguments listu object? tipa, ali ovde neam validator, jer samo id argument stize sa FE

                /* Koristim TimeProvider iako je to isto kao DateTimeOffset, ali ovo se moze lakse testirati nego DateTimeOffset
                   TimeProvider, ContractsDbContext i IEventBus moram da registrujem u DI */
                var pass = await dbContext.Passes.FindAsync([id], cancellationToken); // FinAsyn samo za PK moze 
                if (pass is null)
                    return Results.NotFound();

                var now = timeProvider.GetUtcNow();

                pass.MarkAsExpired(now); // Change Tracker ukljucen 
                await dbContext.SaveChangesAsync(cancellationToken); // Vrstu koja se odnosi na pass objekat azurirace zbog change tracker

                await eventBus.PublishAsync(PassExpiredEvent.Create(pass.Id, pass.CustomerId, timeProvider.GetUtcNow()), cancellationToken); // Publish u EventBus PassExpiredEvent koji je automatski handled u Offers.PrepareOffer.PassExpiredEventHandler

                return Results.NoContent();
            }); // Nema validator jer nemam Request kao Endpoint argument
        }
    }
}
