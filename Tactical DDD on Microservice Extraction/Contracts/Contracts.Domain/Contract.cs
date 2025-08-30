
using Common.Domain; // Tools -> NuGet Package Manager -> Setting -> da pokazuje na T DDD Common.Domain jer tu je V2.0.0
using Common.Domain.BusinessRules;
using Contracts.Domain.PrepareContract;
using Contracts.Domain.PrepareContract.BusinessRules;
using Contracts.Domain.SignContract.BusinessRules;
using Contracts.Domain.SignContract.Signatures;
using ErrorOr; // Napravio NuGet from Common.Domain i onda instalirao u Contracts.Domain via NuGet manager

namespace Contracts.Domain
{
    public sealed class Contract : Entity
    {   // ContracId da ne bude primary obsession
        private static TimeSpan StandardDuration => TimeSpan.FromDays(365);
        public ContractId Id { get; init; }
        public Guid CustomerId { get; init; }
        public DateTimeOffset PreparedAt { get; init; }
        public TimeSpan Duration { get; init; }
        public Signature? Signature { get; private set; }
        public DateTimeOffset? ExpiringAt { get; private set; }

        public bool IsSigned => Signature is not null;
        
        // EF Core needs this TO create non-primitive types. Znam iz EShopMicroservices
        private Contract() { }
        private Contract(Guid customerId, DateTimeOffset preparedAt, TimeSpan duration)
        {
            Id = ContractId.Create();
            CustomerId = customerId;
            PreparedAt = preparedAt;
            Duration = duration;

            var domainEvent = ContractPreparedDomainEvent.Raise(CustomerId, PreparedAt);
            RecordDomainEvent(domainEvent);

        }

        public static ErrorOr<Contract> Prepare(Guid customerId, int customerAge, int customerHeight, DateTimeOffset preparedAt, bool? isPreviousContractSigned = null)
        {
            return BusinessRuleValidator.Validate(new ContractCanBePreparedOnlyForAdultRule(customerAge),
                                           new CustomerMustBeSmallerThanMaximumHeightLimitRule(customerHeight),
                                           new PreviousContractHasToBeSignedRule(isPreviousContractSigned)).Then<Contract>(_ => new Contract(customerId, preparedAt, StandardDuration)); 

        }

        public ErrorOr<BindingContract> Sign(Signature signature, DateTimeOffset now)
        {
            return BusinessRuleValidator.Validate(new ContractMustNotBeAlreadySignedRule(IsSigned),
                                                  new ContractCanOnlyBeSignedWithin30DaysFromPreparationRule(PreparedAt, signature.Date))
                                 .Then(_ =>
                                 {
                                     Signature = signature;
                                     ExpiringAt = now.Add(Duration);
                                     var bindingContract = BindingContract.Start(Id, CustomerId, Duration, now, ExpiringAt.Value);

                                     return bindingContract;
                                 });
        }
    }
}
