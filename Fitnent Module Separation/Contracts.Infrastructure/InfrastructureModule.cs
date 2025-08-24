using Contracts.Application;
using Contracts.Infrastructure.Database;

namespace Contracts.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddContractsInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddContractsDatabase(configuration);
            services.AddMediationModule();
            services.AddScoped<IContractsModule, ContractsModule>(); // IContractModule je u Application layer i uvek Scoped registrujem ga

            return services;
        }

        public static IApplicationBuilder UseContractsInfrastructure(this IApplicationBuilder app)
        {
            app.UseContractsDatabase();
            return app;
        }
    }
}
