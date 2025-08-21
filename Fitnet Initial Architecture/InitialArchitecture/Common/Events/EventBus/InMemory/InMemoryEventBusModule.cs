using System.Reflection;

namespace InitialArchitecture.Common.Events.EventBus.InMemory
{
    internal static class InMemoryEventBusModule
    {
        public static IServiceCollection AddInMemoryEventBus(this IServiceCollection services, Assembly assembly)
        {
            services.AddScoped<IEventBus, InMemoryEventBus>(); // Registrujem IEventBus da se odnosi na InMemoryEventBus
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly)); // Dodam MediatR jer in-memory event bus zahteva MediatR za Publish-Subscribe

            return services; // => u Program.cs mogu builder.Services.AddInMemoryEventBus()...
        }
    }
}
