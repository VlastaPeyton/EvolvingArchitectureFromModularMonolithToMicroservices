
using Contracts.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Contracts.Infrastructure.Mediation
{
    internal static class MediationModule
    {
        public static IServiceCollection AddMediationModule(this IServiceCollection services) 
        { 
            var commandsHandlersAssembly = typeof(IContractsModule).Assembly; // Contracts.Application Assembly, jer tamo je CommandHandler smesten za svaki write db Request(Command)
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(commandsHandlersAssembly));
            
            return services;
        }
    }
}
