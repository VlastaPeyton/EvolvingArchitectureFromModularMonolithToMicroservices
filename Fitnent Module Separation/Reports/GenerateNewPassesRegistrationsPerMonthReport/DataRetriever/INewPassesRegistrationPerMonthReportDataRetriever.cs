namespace Reports.GenerateNewPassesRegistrationsPerMonthReport.DataRetriever
{
    internal interface INewPassesRegistrationPerMonthReportDataRetriever
    {
        Task<IReadOnlyCollection<NewPassesRegistrationsPerMonthDto>> GetReportDataAsync(CancellationToken cancellationToken);
    }
}
