using Microsoft.EntityFrameworkCore;

namespace InitialArchitecture.Contracts.Data.Database
{   
    internal static class DatabaseModule
    {
        private const string ConnectionStringName = "Contracts";

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {   // IConfiguration jer builder.Configuration je tog tipa u Program.cs 
            var connectionString = configuration.GetConnectionString(ConnectionStringName); // Ocita iz appsettings.json 
            services.AddDbContext<ContractsDbContext>(options => options.UseNpgsql(connectionString)); // <= Npgsql.EntityFrameworkCore.PostgreSQL NuGet
            
            return services; // => u Program.cs mogu builder.AddDatabase(Builder.configuration)...
        }
        public static IApplicationBuilder UseDatabase(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseAutoMigrations(); // UseAutoMigrations je extension from AutoMigrationExtensions.cs

            return applicationBuilder; // => u Program.cs mogu app.UseDatabase()...
        }
    }
}
