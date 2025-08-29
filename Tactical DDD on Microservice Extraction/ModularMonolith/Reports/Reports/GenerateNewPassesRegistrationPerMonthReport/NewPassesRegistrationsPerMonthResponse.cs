

namespace Reports.GenerateNewPassesRegistrationPerMonthReport
{
    internal record NewPassesRegistrationsPerMonthResponse(IReadOnlyCollection<NewPassesRegistrationsPerMonthDTO> PassesRegistrationsPerMonth)
    {
        public static NewPassesRegistrationsPerMonthResponse Create(IReadOnlyCollection<NewPassesRegistrationsPerMonthDTO> passesRegistrationsPerMonth)
        {
            return new NewPassesRegistrationsPerMonthResponse(passesRegistrationsPerMonth);
        }
    }
}
