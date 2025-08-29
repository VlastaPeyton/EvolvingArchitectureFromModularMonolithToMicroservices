using InitialArchitecture.Reports.GenerateNewPassesRegistrationsPerMonthReport.DataRetriever;

namespace InitialArchitecture.Reports.GenerateNewPassesRegistrationsPerMonthReport
{
    internal static class GenerateNewPassesRegistrationsPerMonthReportEndpoint
    {
        public static void MapGenerateNewPassesRegistrationsPerMonthReport(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/reports", async (INewPassesRegistrationsPerMonthReportDataRetriever dataRetriever, CancellationToken cancellationToken) =>
            {
                var reportData = await dataRetriever.GetReportDataAsync(cancellationToken);
                var newPassesRegistrationsPerMonthResponse = NewPassesRegistrationsPerMonthResponse.Create(reportData);

                return Results.Ok(newPassesRegistrationsPerMonthResponse); 

            }); // Nema VallidateRequest jer Endpoint nema Request argument
        }
    }
}
