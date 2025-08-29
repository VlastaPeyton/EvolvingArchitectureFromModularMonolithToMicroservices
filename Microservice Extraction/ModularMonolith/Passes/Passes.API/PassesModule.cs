
using System.Reflection;
using Common.Infrastructure.Mediator;
using Common.Infrastructure.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Passes.API.EventBus;
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
            app.MapPassesEndpoints();
        }

        private static IApplicationBuilder UsePasses(this IApplicationBuilder app)
        {
            app.UsePassesDataAccess();
            return app;
        }

        public static IServiceCollection AddPasses(this IServiceCollection services, IConfiguration configuration, string module)
        {
            if(!configuration.IsModuleEnabled(module))
                return services;

            services.AddPassesDataAccess(configuration);
            services.AddMediator(Assembly.GetExecutingAssembly()); // Iz Common.Infrastructure
            services.AddEventBus(configuration); // Iz EventBusModule.cs

            return services;
        }
    }
}
