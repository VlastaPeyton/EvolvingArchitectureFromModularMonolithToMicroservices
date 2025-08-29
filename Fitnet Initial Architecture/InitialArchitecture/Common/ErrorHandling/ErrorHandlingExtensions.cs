namespace InitialArchitecture.Common.ErrorHandling
{
    internal static class ErrorHandlingExtensions
    {
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder appBuilder)
        {
            appBuilder.UseExceptionHandler(); // built-in metoda
            
            return appBuilder; // => u Program.cs pisem app.UseErrorHandling()
        }

        public static IServiceCollection AddExceptionHandling(this IServiceCollection services) 
        {
            services.AddExceptionHandler<GlobalExceptionHandler>(); // built-in metoda 
            services.AddProblemDetails(); // built-in metoda

            return services; // => u Program.cs pisem builder.Services.AddExceptionHandling()
        }
    }
}
