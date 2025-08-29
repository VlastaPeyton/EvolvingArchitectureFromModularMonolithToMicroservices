using Reports.GenerateNewPassesRegistrationsPerMonthReport.DataRetriever;

namespace Reports.GenerateNewPassesRegistrationsPerMonthReport
{
    internal static class GenerateNewPassesPerMonthReportEndpoint
    {
        internal static void MapGenerateNewPassesRegistrationsPerMonthReport(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/reports", async (INewPassesRegistrationPerMonthReportDataRetriever dataRetriever, CancellationToken cancellationToken) =>
            {
                var reportData = await dataRetriever.GetReportDataAsync(cancellationToken);
                var newPassesRegistrationsPerMonthResponse = NewPassesRegistrationsPerMonthResponse.Create(reportData);

                return Results.Ok(newPassesRegistrationsPerMonthResponse);
            });
        }
    }
}
