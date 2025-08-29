using FluentValidation;
using InitialArchitecture.Common.Validation;
using InitialArchitecture.Contracts.Data;
using InitialArchitecture.Contracts.Data.Database;
using Microsoft.EntityFrameworkCore;

namespace InitialArchitecture.Contracts.PrepareContract
{   
    // Extension for IEndpointRouteBuilder, jer se taj interface koristi za definisanje Minimal API Endpoint
    internal static class PrepareContractEndpoint
    {   
        // Prepare contract i staviti ga u bazu jer mora ovo pre nego sto Sign contract
        internal static void MapPrepareContract(this IEndpointRouteBuilder app)
        {   // Endpoint se pokrece tek kad ValidateRequest<PrepareContractRequest> zavrsi 
            app.MapPost("/api/contracts", async (PrepareContractRequest request, ContractsDbContext dbContext, CancellationToken cancellationToken) =>
            {   // Ove argumente u Endpoint, RequestValidationApiFilter vidi kao Arguments listu object? tipa
                // ContractsDbContext moram da registrujem u DI da bi ga Minimal Api Endpoint prepoznao 

                var previousContract = await GetPreviousContractForCustomerAsync(dbContext, request.CustomerId, cancellationToken);

                var contract = Contract.Prepare(request.CustomerId, request.CustomerAge, request.CustomerHeight, request.PreparedAt, previousContract?.Signed);
                // Napravljen ugovor sa StandardDuration 

                await dbContext.Contracts.AddAsync(contract, cancellationToken);
                await dbContext.SaveChangesAsync(cancellationToken);

                return Results.Created($"/api/contracts/{contract.Id}", contract.Id);

            }).ValidateRequest<PrepareContractRequest>() // Exntension iz EndpointBuilderExtensions.cs koji validira request pre nego sto udje u ovaj Minimal API Endpoint
              .Produces<string>(StatusCodes.Status201Created)
              .Produces(StatusCodes.Status409Conflict)
              .Produces(StatusCodes.Status500InternalServerError);
        }

        private static async Task<Contract?> GetPreviousContractForCustomerAsync(ContractsDbContext dbContext, Guid customerId, CancellationToken cancellationToken)
        {
            return await dbContext.Contracts.OrderByDescending(contract => contract.PreparedAt).SingleOrDefaultAsync(contract => contract.CustomerId == customerId, cancellationToken);
        }
    }
}
