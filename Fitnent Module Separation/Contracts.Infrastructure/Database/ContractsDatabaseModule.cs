using Contracts.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Contracts.Infrastructure.Database
{
    internal static class ContractsDatabaseModule
    {
        private const string ConnectionStringConfigurationSection = "Modules:Contracts:ConnectionStrings:Primary";
        // Ovo je u appsettings.json ovako namesteno

        public static IServiceCollection AddContractsDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection(ConnectionStringConfigurationSection).Value;
            services.AddDbContext<ContractsDbContext>(options => options.UseNpgsql(connectionString));
            // AddDbContext je Scoped automatski i zato AddContractsRepositories mora biti Scoped
            services.AddContractsRepositories(); // Extension iz Repositories foldera

            return services;
        }

        public static IApplicationBuilder UseContractsDatabase(this IApplicationBuilder app)
        {
            app.UseAutoContractsMigrations();
            return app;
        }
    }
}
