namespace Reports.GenerateNewPassesRegistrationsPerMonthReport
{
    public sealed record NewPassesRegistrationsPerMonthResponse(IReadOnlyCollection<NewPassesRegistrationsPerMonthDto> PassesRegistrationsPerMonth)
    {
        internal static NewPassesRegistrationsPerMonthResponse Create(IReadOnlyCollection<NewPassesRegistrationsPerMonthDto> passesRegistrationsPerMonth) => new(passesRegistrationsPerMonth);
    }
}
