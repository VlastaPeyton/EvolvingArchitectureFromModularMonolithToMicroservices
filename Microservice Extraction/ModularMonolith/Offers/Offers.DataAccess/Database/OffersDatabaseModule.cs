

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Offers.DataAccess.Database
{
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
            applicationBuilder.UseAutoOfferMigrations();
            return applicationBuilder;
        }
    }
}
