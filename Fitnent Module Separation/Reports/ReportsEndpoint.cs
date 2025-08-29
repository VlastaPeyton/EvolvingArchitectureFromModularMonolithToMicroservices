using Reports.GenerateNewPassesRegistrationsPerMonthReport;

namespace Reports
{
    internal static class ReportsEndpoints
    {
        internal static void MapReports(this IEndpointRouteBuilder app)
        {
            app.MapGenerateNewPassesRegistrationsPerMonthReport();
        }
    }
}
