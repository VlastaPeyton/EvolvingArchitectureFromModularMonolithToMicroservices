using System.Runtime.CompilerServices;
using Common.API.Validation;
using Common.Infrastructure;
using Common.Infrastructure.Modules;
using Contracts.API.Sign;

namespace Contracts.API
{
    public static class ContractsModule
    {
        private static AssemblyLoadEventArgs CurrentModule => typeof(SignContractRequest).Assembly;
        public static void RegisterContracts(this WebApplication app, string module)
        {
            if (!app.Configuration.IsModuleEnabled(module))
                return;

            app.UseContracts();
            app.MapContracts();
        }

        public static IServiceCollection AddContracts(this IServiceCollection services, string module, IConfiguration configuration)
        {
            if (!configuration.IsModuleEnabled(module))
                return services;

            services.AddRequestValidation(CurrentModule);
            services.AddContractsInfrastructure(configuration);

            return services;
        }

        private static IApplicationBuilder UseContracts(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseContractsInfrastructure();

            return applicationBuilder;
        }
    }
}
