namespace InitialArchitecture.Reports.GenerateNewPassesRegistrationsPerMonthReport.DataRetriever
{
    public interface INewPassesRegistrationsPerMonthReportDataRetriever
    {
        Task<IReadOnlyCollection<NewPassesRegistrationsPerMonthDTO>> GetReportDataAsync(CancellationToken cancellationToken);
    }
}
