
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Passes.DataAccess.Database;

namespace Passes.DataAccess
{
    public static class DataAccessModule
    {
        public static IServiceCollection AddPassesDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPassesDatabase(configuration);

            return services;
        }

        public static IApplicationBuilder UsePassesDataAccess(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UsePassesDatabase();

            return applicationBuilder;
        }
    }
}
