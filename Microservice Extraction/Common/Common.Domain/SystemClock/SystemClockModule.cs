
using Microsoft.Extensions.DependencyInjection;

namespace Common.Domain.SystemClock
{
    public static class SystemClockModule
    {
        public static IServiceCollection AddSystemClock(this IServiceCollection services)
        {
            services.AddSingleton<ISystemClock, SystemClock>(); // Kao Singleton treba bas kao TimeProvider jer ocu da ga testiram 
            return services;
        }
    }
}
