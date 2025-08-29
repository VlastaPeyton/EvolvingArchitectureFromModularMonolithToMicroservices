using System.Reflection;

namespace Common.Infrastructure.Mediator
{
    public static class MediatorModule
    {
        public static IServiceCollection AddMediator(this IServiceCollection services, Assembly assembly)
        {   // AddMediatR je iz MediatR NuGet
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly)); 
            return services;
        }
    }
}
