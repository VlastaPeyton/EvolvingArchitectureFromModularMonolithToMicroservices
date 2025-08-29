using Reports.DataAccess;
using Reports.GenerateNewPassesRegistrationsPerMonthReport;

namespace Reports
{
    public static class ReportsModule
    {
        public static void RegisterReports(this WebApplication app, string module)
        {
            if (!app.Configuration.IsModuleEnabled(module))
            {
                return;
            }

            app.UseReports();
            app.MapReports();
        }

        public static IServiceCollection AddReports(this IServiceCollection services, string module, IConfiguration configuration)
        {
            if (!configuration.IsModuleEnabled(module))
            {
                return services;
            }

            services.AddReportsDataAccess();
            services.AddNewPassesRegistrationsPerMonthReport();

            return services;
        }

        private static IApplicationBuilder UseReports(this IApplicationBuilder applicationBuilder) =>
            applicationBuilder;
    }
}
