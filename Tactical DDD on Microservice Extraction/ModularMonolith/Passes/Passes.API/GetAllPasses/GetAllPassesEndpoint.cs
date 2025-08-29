using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Passes.DataAccess.Database;

namespace Passes.API.GetAllPasses
{
    internal static class GetAllPassesEndpoint
    {
        public static void MapGetAllPassesEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/passes", async (PassesDbContext dbContext, CancellationToken cancellationToken) =>
            {
                var passesDTOs = await dbContext.Passes.AsNoTracking().Select(pass => PassDTO.From(pass)).ToListAsync();

                var response = GetAllPassesResponse.Create(passesDTOs);

                return Results.Ok(response);
            }); // Nema ValidateRequest jer nema Request u ovaj endpoint
        }
    }
}
