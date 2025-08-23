using InitialArchitecture.Reports.DataAccess;
using InitialArchitecture.Reports.GenerateNewPassesRegistrationsPerMonthReport.DataRetriever;

namespace InitialArchitecture.Reports.GenerateNewPassesRegistrationsPerMonthReport
{
    internal static class GenerateNPPMReportModule
    {
        public static IServiceCollection AddNewPassesRegistrationsPerMonthReport(this IServiceCollection services)
        {   
            // TimeProvider i IDatabaseFactory su AddSingleton => mora i ovde AddSingleton
            services.AddSingleton<INewPassesRegistrationsPerMonthReportDataRetriever, NPRPMReportDataRetriever>();
            services.AddReportsDataAcces();  // Registracija fabrike za pravljenje conn string zbog Dapper
            return services;
        }
    }
}
