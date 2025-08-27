
using Common.Domain.BusinessRules;
using Contracts.Domain.PrepareContract.BusinessRules;
using Contracts.Domain.SignContract.BusinessRules; // Napravio NuGet from Common.Domain i onda instalirao u Contracts.Domain via NuGet manager

namespace Contracts.Domain
{
    public sealed class Contracts
    {
        private static TimeSpan StandardDuration => TimeSpan.FromDays(365);

        public Guid Id { get; init; }
        public Guid CustomerId { get; init; }
        public DateTimeOffset PreparedAt { get; init; }
        public TimeSpan Duration { get; init; }
        public DateTimeOffset? SignedAt { get; private set; }
        public DateTimeOffset? ExpiringAt { get; private set; }

        public bool IsSigned => SignedAt.HasValue;
        
        private Contracts(Guid id, Guid customerId, DateTimeOffset preparedAt, TimeSpan duration)
        {
            Id = id;
            CustomerId = customerId;
            PreparedAt = preparedAt;
            Duration = duration;
        }

        public static Contracts Prepare(Guid customerId, int customerAge, int customerHeight, DateTimeOffset preparedAt, bool? isPreviousContractSigned = null)
        {
            BusinessRuleValidator.Validate(new ContractCanBePreparedOnlyForAdultRule(customerAge));
            BusinessRuleValidator.Validate(new CustomerMustBeSmallerThanMaximumHeightLimitRule(customerHeight));
            BusinessRuleValidator.Validate(new PreviousContractHasToBeSignedRule(isPreviousContractSigned));

            return new(Guid.NewGuid(), customerId, preparedAt, StandardDuration);
        }

        public void Sign(DateTimeOffset signedAt, DateTimeOffset today)
        {
            BusinessRuleValidator.Validate(new ContractCanOnlyBeSignedWithin30DaysFromPreparation(signedAt, today));

            SignedAt = signedAt;
            ExpiringAt = today.Add(Duration);
        }
    }
}
