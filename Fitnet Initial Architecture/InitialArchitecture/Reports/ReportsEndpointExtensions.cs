using InitialArchitecture.Reports.GenerateNewPassesRegistrationsPerMonthReport;

namespace InitialArchitecture.Reports
{
    internal static class ReportsEndpointExtensions
    {
        public static void MapReports(this IEndpointRouteBuilder app)
        {
            app.MapGenerateNewPassesRegistrationsPerMonthReport();
        }
    }
}
