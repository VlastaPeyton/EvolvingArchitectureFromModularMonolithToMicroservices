
using Microsoft.Extensions.DependencyInjection;

namespace Common.Infrastructure.Clock
{
    public static class ClockModule
    {
        public static IServiceCollection AddClock(this IServiceCollection services)
        {
            services.AddSingleton(TimeProvider.System); // Znam da TimeProvider mora DI (Singleton), a ne kao library obican, jer ocu da ga testiram
            return services;
        }
    }
}
