

namespace Reports.GenerateNewPassesRegistrationPerMonthReport.DataRetriever
{
    internal interface INewPassesRegistrationPerMonthReportDataRetriever
    {
        Task<IReadOnlyCollection<NewPassesRegistrationsPerMonthDTO>> GetReportDataAsync(CancellationToken cancellationToken);
    }
}
