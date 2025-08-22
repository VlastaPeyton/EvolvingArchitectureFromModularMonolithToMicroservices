using InitialArchitecture.Passes.Data.Database;
using Microsoft.EntityFrameworkCore;

namespace InitialArchitecture.Passes.GetAllPasses
{
    internal static class GetAllPassesEndpoint
    {
        public static void MapGetAllPasses(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/passes", async (PassesDbContext dbContext, CancellationToken cancellationToken) =>
            {
                var passDTOs = await dbContext.Passes.AsNoTracking() // Jer citam iz baze i tad pozeljno da ugasim Change Tracker zbog brzine rada i memorije
                                                    .Select(pass => PassDTO.From(pass))
                                                    .ToListAsync(cancellationToken);

                var response = GetAllPassesResponse.Create(passDTOs);

                return Results.Ok(response); // FE ce biti poslato 200 u StatusCode i response object u Body of Response

            }); // Nema validacija jer nema Request koji gadja endpoint
        }
    }
}
