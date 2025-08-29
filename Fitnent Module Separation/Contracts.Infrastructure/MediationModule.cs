using Contracts.Application;

namespace Contracts.Infrastructure
{
    internal static class MediationModule
    {
        public static IServiceCollection AddMediationModule(this IServiceCollection services)
        {   // Zato sto IContractsModule nije u Contracts.Infrastructure, vec u Contracts.Application layer
            var commandsHandlersAssembly = typeof(IContractsModule).Assembly; // IContractModule je u Application layer

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(commandsHandlersAssembly));
            return services;
        }
    }
}
