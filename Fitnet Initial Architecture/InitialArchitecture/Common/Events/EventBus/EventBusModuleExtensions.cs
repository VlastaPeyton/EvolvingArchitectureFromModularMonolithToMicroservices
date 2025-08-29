using System.Reflection;
using InitialArchitecture.Common.Events.EventBus.InMemory;

namespace InitialArchitecture.Common.Events.EventBus
{
    internal static class EventBusModuleExtensions
    {
        internal static IServiceCollection AddEventBus(this IServiceCollection services)
        {   // In-memory umesto RabbitMQ eto onako, ali cim ugasim app, sve iz in-memory event bus se brise, dok u RabbitMQ ostaje
            return services.AddInMemoryEventBus(Assembly.GetExecutingAssembly()); // AddInMemoryEventBus je extension iz InMemoryEventBusModuleExtensions.cs
            // => u Program.cs moze builder.Services.AddEventBus()...
        }
    }
}
