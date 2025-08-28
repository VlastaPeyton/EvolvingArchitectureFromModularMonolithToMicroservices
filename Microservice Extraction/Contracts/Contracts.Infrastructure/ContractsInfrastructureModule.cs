
using Contracts.Application;
using Contracts.Infrastructure.Database;
using Contracts.Infrastructure.EventBus;
using Contracts.Infrastructure.Mediation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Contracts.Infrastructure
{
    public static class ContractsInfrastructureModule
    {
        public static IServiceCollection AddContractsInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddContractsDatabase(configuration);
            services.AddMediationModule();
            services.AddEventBus(configuration);
            services.AddScoped<IContractsModule, ContractsModule>();

            return services;
        }

        public static IApplicationBuilder UseContractsInfrastructure(this IApplicationBuilder app)
        {
            app.UseContractsDatabase();
            return app;
        }
    }
}
