using Microsoft.EntityFrameworkCore;

namespace InitialArchitecture.Offers.Data.Database
{   
    // Objasnjeno u Contracts
    internal static class OffersDatabaseModule
    {
        private const string ConnectionStringName = "Offers";

        public static IServiceCollection AddOffersDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(ConnectionStringName);
            services.AddDbContext<OffersDbContext>(options => options.UseNpgsql(connectionString));

            return services;
        }

        public static IApplicationBuilder UseOffersDatabase(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseAutomaticOffersMigrations();

            return applicationBuilder;
        }
    }
}
