using Common.Infrastructure.Events.EventBus.InMemory;

namespace Common.Infrastructure.Events.EventBus
{
    internal static class EventBusModule
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services)
        {
            services.AddInMemoryEventBus();
            return services;
        }
    }
}
