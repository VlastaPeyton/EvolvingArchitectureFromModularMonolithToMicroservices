using Microsoft.EntityFrameworkCore;

namespace InitialArchitecture.Offers.Data.Database
{   
    // Objasnjeno u Contract
    internal static class OffersAutomaticMigrationsExtensions
    {
        public static IApplicationBuilder UseAutomaticOffersMigrations(this IApplicationBuilder applicationBuilder)
        {
            using var scope = applicationBuilder.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<OffersDbContext>();
            context.Database.Migrate();

            return applicationBuilder;
        }
    }
}
