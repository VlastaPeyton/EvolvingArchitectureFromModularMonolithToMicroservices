using InitialArchitecture.Common.Events.EventBus;
using InitialArchitecture.Common.Validation;
using InitialArchitecture.Contracts.Data.Database;
using InitialArchitecture.Contracts.SignContract.Events;

namespace InitialArchitecture.Contracts.SignContract
{
    // Extension for IEndpointRouteBuilder, jer se taj interface koristi za definisanje Minimal API Endpoint
    internal static class SignContractEndpoint
    {
        internal static void MapSignContract(this IEndpointRouteBuilder app)
        {   // Endpoint se pokrece tek kad ValidateRequest<SignContractRequest> zavrsi 
            app.MapPatch($"api/contracts", async (Guid id, SignContractRequest request, ContractsDbContext dbContext, IEventBus bus, TimeProvider timeProvider, CancellationToken cancellationToken) =>
            {   // Ove argumente u Endpoint, RequestValidationApiFilter vidi kao Arguments listu object? tipa

                // TimeProvider, ContractsDbContext i IEventBus moram da registrujem u DI 

                // Nadji ugovor koji je napravljen pomocu Contract.Prepare i stavljen u bazu u PrepareContractEndpointExtension u MapPrepareContract
                var contract = await dbContext.Contracts.FindAsync([id], cancellationToken); // EF Core change tracks contract . FindAsync samo za PK moze i zato id stavljam. [id], jer dobra praksa ako budem imao Composite PK pa onda [pk1, pk2,...]
                if (contract is null)
                    return Results.NotFound();

                var dateNow = timeProvider.GetUtcNow();

                contract.Sign(request.SignedAt, dateNow);

                await dbContext.SaveChangesAsync(cancellationToken); // Zbog Change Tracking, azurira vrstu, u Contracts tabeli, koja odgovara contract objektu koji je napravljen u PrepareContractEndpointExtension

                // @event, jer event je reserved keyword 
                var @event = ContractSignedEvent.Create(
                    contract.Id,
                    contract.CustomerId,
                    contract.SignedAt!.Value,
                    contract.ExpiringAt!.Value,
                    timeProvider.GetUtcNow());

                await bus.PublishAsync(@event, cancellationToken);

                return Results.NoContent();

            }).ValidateRequest<SignContractRequest>() // Exntension iz EndpointBuilderExtensions.cs koji validira request pre nego sto udje u ovaj Minimal API Endpoint
              .Produces(StatusCodes.Status204NoContent)
              .Produces(StatusCodes.Status404NotFound)
              .Produces(StatusCodes.Status409Conflict)
              .Produces(StatusCodes.Status500InternalServerError);
        }
    }
}
