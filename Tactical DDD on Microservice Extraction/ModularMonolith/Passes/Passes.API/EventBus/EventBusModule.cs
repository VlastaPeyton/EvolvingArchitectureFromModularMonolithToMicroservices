
using System.Reflection;
using MassTransit;
using MassTransit.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Passes.API.EventBus.Outbox;

namespace Passes.API.EventBus
{
    internal static class EventBusModule
    {
        private const string EventBusConfiguration = "EventBus";

        internal static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EventBusOptions>(options => configuration.GetSection(EventBusConfiguration).Bind(options));

            services.AddMassTransit(cfg =>
            {
                cfg.SetSnakeCaseEndpointNameFormatter();
                cfg.AddConsumers(Assembly.GetExecutingAssembly()); // U Contracts nisam imao ovo jer Contracts je Publisher u Message Broker
                cfg.UsingRabbitMq((context, factoryConfigurator) =>
                {
                    var options = context.GetRequiredService<IOptions<EventBusOptions>>();
                    factoryConfigurator.ConfigureEndpoints(context);
                });

                cfg.ConfigureOutbox(); // Iz OutboxExtension.cs
            });

            return services;
        }
    }
}
