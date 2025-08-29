

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Offers.DataAccess.Database;

namespace Offers.DataAccess
{
    public static class OffersDataAccessModule
    {
        public static IServiceCollection AddOffersDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOffersDatabase(configuration);
            return services;
        }

        public static IApplicationBuilder UseOffersDataAcces(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseOffersDatabase();
            return applicationBuilder;
        }
    }
}
