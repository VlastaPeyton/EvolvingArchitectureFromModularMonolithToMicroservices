

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Infrastructure.Mediator
{
    public static class MediatorModule
    {
        public static IServiceCollection AddMediator(this IServiceCollection services, Assembly assembly)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly)); 
            return services;
        }
    }
}
