namespace Reports.GenerateNewPassesRegistrationsPerMonthReport
{
    public sealed record NewPassesRegistrationsPerMonthDto(int MonthOrder, string MonthName, long RegisteredPasses);
}
