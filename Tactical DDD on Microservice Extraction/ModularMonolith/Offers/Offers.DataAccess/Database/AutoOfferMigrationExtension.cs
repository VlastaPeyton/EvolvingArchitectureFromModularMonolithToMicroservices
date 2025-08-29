

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Offers.DataAccess.Database
{
    internal static class AutoOfferMigrationExtension
    {
        internal static IApplicationBuilder UseAutoOfferMigrations(this IApplicationBuilder applicationBuilder)
        {
            using var scope = applicationBuilder.ApplicationServices.CreateScope(); 
            var context = scope.ServiceProvider.GetRequiredService<OffersDbContext>();
            context.Database.Migrate();

            return applicationBuilder;
        }
    }
}
