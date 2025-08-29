
using Microsoft.Extensions.DependencyInjection;
using Reports.GenerateNewPassesRegistrationPerMonthReport.DataRetriever;

namespace Reports.GenerateNewPassesRegistrationPerMonthReport
{
    internal static class GNPRPMRModule
    {
        public static IServiceCollection AddNewPassesRegistrationsPerMonthReport(this IServiceCollection services)
        {   // TimeProvider i IDatabaseFactory su AddSingleton => mora i ovde AddSingleton
            services.AddSingleton<INewPassesRegistrationPerMonthReportDataRetriever, NewPassesRegistrationPerMonthReportDataRetriever>();
            return services;
        }
    }
}
