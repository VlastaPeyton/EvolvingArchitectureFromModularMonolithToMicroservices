namespace Common.API.ErrorHandling
{
    public static class ErrorHandlingExtensions
    {
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseExceptionHandler();

            return applicationBuilder;
        }

        public static IServiceCollection AddExceptionHandling(this IServiceCollection services)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();

            return services;
        }
    }
}
