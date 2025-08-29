namespace Common.Infrastructure.Events.EventBus.InMemory
{
    public static class InMemoryEventBusModule
    {
        public static IServiceCollection AddInMemoryEventBus(this IServiceCollection services)
        {
            services.AddScoped<IEventBus, InMemoryEventBus>();
            return services;
        }
    }
}
