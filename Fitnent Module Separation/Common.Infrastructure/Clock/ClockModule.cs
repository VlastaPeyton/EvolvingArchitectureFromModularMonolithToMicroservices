namespace Common.Infrastructure.Clock
{
    internal static class ClockModule
    {
        public static IServiceCollection AddClock(this IServiceCollection services)
        {
            services.AddSingleton(TimeProvider.System);
            return services;
        }
    }
}
