using InitialArchitecture.Passes.Data.Database;

namespace InitialArchitecture.Passes
{
    internal static class PassesModuleExtensions
    {
        public static IServiceCollection AddPasses(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPassesDatabase(configuration);
            return services;
        }

        public static IApplicationBuilder UsePasses(this IApplicationBuilder app)
        {
            app.UsePassesDatabase();
            return app;
        }
            
    }
}
