using Microsoft.EntityFrameworkCore;

namespace InitialArchitecture.Contracts.Data.Database
{   
    internal static class ContractsDatabaseModule
    {
        private const string ConnectionStringName = "Contracts";

        public static IServiceCollection AddContractsDatabase(this IServiceCollection services, IConfiguration configuration)
        {   // IConfiguration jer builder.Configuration je tog tipa u Program.cs 
            var connectionString = configuration.GetConnectionString(ConnectionStringName); // Ocita iz appsettings.json 
            services.AddDbContext<ContractsDbContext>(options => options.UseNpgsql(connectionString)); // <= Npgsql.EntityFrameworkCore.PostgreSQL NuGet
            // AddDbContext je Scoped automatski 
            return services; // => u Program.cs mogu builder.AddDatabase(Builder.configuration)...
        }
        public static IApplicationBuilder UseContractsDatabase(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseAutoContractsMigrations(); // UseAutoMigrations je extension from AutoMigrationExtensions.cs

            return applicationBuilder; // => u Program.cs mogu app.UseDatabase()...
        }
    }
}
