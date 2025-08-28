
using Contracts.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Contracts.API
{
    public static class ContractsApiModule
    {
        public static void RegisterContractsApi(this WebApplication app)
        {
            app.UseContracts();
            app.MapContractsEndpoints();
        }

        public static IServiceCollection AddContractsApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddContractsInfrastructure(configuration);
            return services;
        }

        public static IApplicationBuilder UseContracts(this IApplicationBuilder app)
        {
            app.UseContractsInfrastructure();
            return app;
        }
    }
}
