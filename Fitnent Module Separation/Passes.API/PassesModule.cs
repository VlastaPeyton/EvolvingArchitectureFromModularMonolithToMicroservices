using System.Reflection;
using Common.Infrastructure.Modules;
using Common.Infrastructure.Mediator;
using Passes.DataAccess;

namespace Passes.API
{
    public static class PassesModule
    {
        public static void RegisterPasses(this WebApplication app, string module)
        {
            if (!app.Configuration.IsModuleEnabled(module))
                return;

            app.UsePasses();
            app.MapPasses();
        }

        public static IServiceCollection AddPasses(this IServiceCollection services, string module, IConfiguration configuration)
        {
            if (!configuration.IsModuleEnabled(module))
            {
                return services;
            }

            services.AddDataAccess(configuration);
            services.AddMediator(Assembly.GetExecutingAssembly());

            return services;
        }

        private static IApplicationBuilder UsePasses(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseDataAccess();

            return applicationBuilder;
        }
    }
}
