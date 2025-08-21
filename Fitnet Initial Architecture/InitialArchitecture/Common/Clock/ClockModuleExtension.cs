﻿namespace InitialArchitecture.Common.Clock
{
    internal static class ClockModuleExtension
    {   // Kako bih mogao u Minimal Api Endpoint da koristim TimeProvider
        public static IServiceCollection AddClock(this IServiceCollection services)
        {
            return services.AddSingleton(TimeProvider.System); // => u Program.cs moram builder.Services.AddClock()
        }
    }
}
