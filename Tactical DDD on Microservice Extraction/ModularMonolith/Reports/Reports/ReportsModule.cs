
using Common.Infrastructure.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reports.DataAccess;
using Reports.GenerateNewPassesRegistrationPerMonthReport;

namespace Reports
{
    public static class ReportsModule
    {
        public static void RegisterReports(this WebApplication app, string module)
        {
            if (!app.Configuration.IsModuleEnabled(module))
                return;

            app.UseReports();
            app.MapReports();
        }

        private static IApplicationBuilder UseReports(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder;
        }

        public static IServiceCollection AddReports(this IServiceCollection services, IConfiguration configuration, string module)
        {
            if (!configuration.IsModuleEnabled(module))
                return services;

            services.AddReportsDataAcces();
            services.AddNewPassesRegistrationsPerMonthReport();

            return services;
        }
    }
}
