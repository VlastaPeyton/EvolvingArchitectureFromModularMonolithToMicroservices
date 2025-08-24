using Microsoft.EntityFrameworkCore;
using Passes.DataAccess.Database;

namespace Passes.API.GetAllPasses
{
    internal static class GetAllPassesEndpoint
    {
        internal static void MapGetAllPasses(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/passes", async (PassesDbContext dbContext, CancellationToken ct) =>
            {
                var passes = await dbContext.Passes.AsNoTracking().Select(pass => PassDto.From(pass)).ToListAsync(ct);

                var response = GetAllPassesResponse.Create(passes);

                return Results.Ok(response);
            });
        }
    }
}
