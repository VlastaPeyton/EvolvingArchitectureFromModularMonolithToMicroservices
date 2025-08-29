
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Reports.GenerateNewPassesRegistrationPerMonthReport.DataRetriever;
namespace Reports.GenerateNewPassesRegistrationPerMonthReport
{
    internal static class GNPRPMREndpoint
    {   // U Reports.csproj dodam 	<FrameworkReference Include="Microsoft.AspNetCore.App" /> kako bi IEndpointRouteBuilder mogao
        public static void MapGenerateNewPassesRegistrationsPerMonthReport(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/reports", async (INewPassesRegistrationPerMonthReportDataRetriever dataRetriever, CancellationToken cancellationToken) =>
            {
                var reportData = await dataRetriever.GetReportDataAsync(cancellationToken);
                var newPassesRegistrationsPerMonthResponse = NewPassesRegistrationsPerMonthResponse.Create(reportData);

                return Results.Ok(newPassesRegistrationsPerMonthResponse);
            }); // Nema ValidateRequest kao u Contracts jer Endpoint nema Request kao argument
        }
    }
}
