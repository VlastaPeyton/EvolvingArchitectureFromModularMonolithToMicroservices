

using Contracts.Infrastructure.Database.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Contracts.Infrastructure.Database
{
    internal static class DatabaseModule
    {
        private const string ConnectionStringName = "Contracts";

        public static IServiceCollection AddContractsDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(ConnectionStringName);
            services.AddDbContext<ContractsDbContext>(options => options.UseNpgsql(connectionString));
            services.AddContractsRepository();

            return services;
        }

        public static IApplicationBuilder UseContractsDatabase(this IApplicationBuilder app)
        {
            app.UseAutoContractsMigration();
            return app;
        }
    }
}
