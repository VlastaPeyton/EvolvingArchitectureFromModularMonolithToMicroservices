
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Contracts.Infrastructure.EventBus
{
    internal static class EventBusModule
    {
        private const string EventBusConfiguration = "EventBus";

        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EventBusOptions>(options => configuration.GetSection(EventBusConfiguration).Bind(options));

            services.AddMassTransit(configurator =>
            {
                configurator.SetSnakeCaseEndpointNameFormatter();
                // nema configurator.AddConsumers(...), jer Contracts samo Publish event to Message Broker
                configurator.UsingRabbitMq((context, factoryConfigurator) =>
                {  
                    var options = context.GetRequiredService<IOptions<EventBusOptions>>();
                    
                    factoryConfigurator.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}
