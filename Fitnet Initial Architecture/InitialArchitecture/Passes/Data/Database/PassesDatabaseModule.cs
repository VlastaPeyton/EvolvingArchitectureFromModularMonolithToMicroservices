using Microsoft.EntityFrameworkCore;

namespace InitialArchitecture.Passes.Data.Database
{   
    // Objasnjeno u Contracts
    internal static class PassesDatabaseModule
    {
        private const string ConnectionStringName = "Passes";

        public static IServiceCollection AddPassesDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(ConnectionStringName);
            services.AddDbContext<PassesDbContext>(options => options.UseNpgsql(connectionString));

            return services;
        }

        public static IApplicationBuilder UsePassesDatabase(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseAutomaticPassesMigrations();
            return applicationBuilder;
        }
    }
}
