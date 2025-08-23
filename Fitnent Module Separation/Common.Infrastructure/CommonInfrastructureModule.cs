using Common.Infrastructure.Clock;
using Common.Infrastructure.Events.EventBus;

namespace Common.Infrastructure
{
    public static class CommonInfrastructureModule
    {
        public static IServiceCollection AddCommonInfrastructure(this IServiceCollection services)
        {
            services.AddEventBus();
            services.AddClock();

            return services;
        }
    }
}
