
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Offers.DataAccess.Database;

namespace Offers.DataAccess
{
    public static class DataAccessModule
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOffersDatabase(configuration);

            return services;
        }

        public static IApplicationBuilder UseDataAccess(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseOffersDatabase();

            return applicationBuilder;
        }
    }
}
