using Reports.GenerateNewPassesRegistrationsPerMonthReport.DataRetriever;

namespace Reports.GenerateNewPassesRegistrationsPerMonthReport
{   
    // Objasnjeno u InternalArchitecture
    internal static class GenerateNewPassesPerMonthReportModule
    {
        internal static IServiceCollection AddNewPassesRegistrationsPerMonthReport(this IServiceCollection services)
        {
            services.AddSingleton<INewPassesRegistrationPerMonthReportDataRetriever, NewPassesRegistrationPerMonthReportDataRetriever>();

            return services;
        }
    }
}
