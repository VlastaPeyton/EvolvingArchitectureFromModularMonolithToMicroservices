using InitialArchitecture.Reports.DataAccess;
using InitialArchitecture.Reports.GenerateNewPassesRegistrationsPerMonthReport;

namespace InitialArchitecture.Reports
{
    internal static class ReportsModuleExtensions
    {
        public static IServiceCollection AddReports(this IServiceCollection services)
        {
            services.AddReportsDataAcces();
            services.AddNewPassesRegistrationsPerMonthReport();

            return services;
        }

        public static IApplicationBuilder UseReports(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
