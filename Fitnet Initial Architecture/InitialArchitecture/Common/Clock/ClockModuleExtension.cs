namespace InitialArchitecture.Common.Clock
{   
    // Koristim TimeProvider iako je to isto kao DateTimeOffset, ali ovo se moze lakse testirati nego DateTimeOffset
    internal static class ClockModuleExtension
    {   // Kako bih mogao u Minimal Api Endpoint da koristim TimeProvider
        public static IServiceCollection AddClock(this IServiceCollection services)
        {
            return services.AddSingleton(TimeProvider.System); // => u Program.cs moram builder.Services.AddClock()
        }
    }
}
