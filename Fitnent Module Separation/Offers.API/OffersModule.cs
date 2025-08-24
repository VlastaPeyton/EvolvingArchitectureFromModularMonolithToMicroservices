using System.Reflection;
using Offers.DataAccess;
using Common.Infrastructure.Mediator;

namespace Offers.API
{
    public static class OffersModule
    {
        public static void RegisterOffers(this WebApplication app, string module)
        {
            if (!app.Configuration.IsModuleEnabled(module))
            {
                return;
            }

            app.UseOffers();
        }

        public static IServiceCollection AddOffers(this IServiceCollection services,
            string module,
            IConfiguration configuration)
        {
            if (!configuration.IsModuleEnabled(module))
            {
                return services;
            }

            services.AddDataAccess(configuration);
            services.AddMediator(Assembly.GetExecutingAssembly());

            return services;
        }

        private static IApplicationBuilder UseOffers(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseDataAccess();

            return applicationBuilder;
        }
    }
}
