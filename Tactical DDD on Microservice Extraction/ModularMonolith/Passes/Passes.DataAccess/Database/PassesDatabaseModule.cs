

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Passes.DataAccess.Database
{
    internal static class PassesDatabaseModule
    {
        private const string ConnectionStringName = "Passes";

        internal static IServiceCollection AddPassesDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(ConnectionStringName);
            services.AddDbContext<PassesDbContext>(options => options.UseNpgsql(connectionString));

            return services;
        }

        internal static IApplicationBuilder UsePassesDatabase(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseAutoPassesMigrations();

            return applicationBuilder;
        }
    }
}
