using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Common.Infrastructure.Mediator;
using Common.Infrastructure.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Offers.DataAccess;

namespace Offers.API
{
    public static class OffersModule
    {
        public static void RegistersOffers(this WebApplication app, string module)
        {
            if (!app.Configuration.IsModuleEnabled(module))
                return;

            app.UseOffers();
        }

        private static IApplicationBuilder UseOffers(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseOffersDataAcces();
            return applicationBuilder;
        }

        public static IServiceCollection AddOffers(this IServiceCollection services, IConfiguration configuration, string module)
        {
            if (!configuration.IsModuleEnabled(module))
            {
                return services;
            }

            services.AddOffersDataAccess(configuration);
            services.AddMediator(Assembly.GetExecutingAssembly());

            return services;
        }
    }

}
