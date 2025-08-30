
using Common.Domain;
using Common.Domain.BusinessRules;
using Contracts.Domain.AttachAnnexToBindingContract.BusinessRule;
using Contracts.Domain.SignContract;
using Contracts.Domain.TerminateBindingContract;
using Contracts.Domain.TerminateBindingContract.BusinessRules;
using ErrorOr;

namespace Contracts.Domain
{
    public sealed class BindingContract : Entity
    {   // BindingContractId/ContractId se radi kako bih izbegao primitive obsessions. Znam iz EShopMicroservices.
        public BindingContractId Id { get; init; }
        public ContractId ContractId { get; init; }
        public Guid CustomerId { get; init; }
        public TimeSpan Duration { get; init; }
        public DateTimeOffset? TerminatedAt { get; set; }
        public DateTimeOffset BindingFrom { get; init; }
        public DateTimeOffset ExpiringAt { get; init; }

        public ICollection<Annex> AttachedAnnexes { get; }

        private BindingContract(ContractId contractId, Guid customerId, TimeSpan duration, DateTimeOffset bindingFrom, DateTimeOffset expiringAt)
        {
            Id = BindingContractId.Create();
            ContractId = contractId;
            CustomerId = customerId;
            Duration = duration;
            ExpiringAt = expiringAt;
            BindingFrom = bindingFrom;
            AttachedAnnexes = [];

            var domainEvent = BindingContractStartedDomainEvent.Raise(BindingFrom, ExpiringAt);
            RecordDomainEvent(domainEvent);
        }

        public static BindingContract Start(ContractId id, Guid customerId, TimeSpan duration, DateTimeOffset bindingFrom, DateTimeOffset expiringAt)
        {
            return new BindingContract(id, customerId, duration, bindingFrom, expiringAt);
        }

        public ErrorOr<AnnexId> AttachAnnex(DateTimeOffset validFrom, DateTimeOffset now)
        {
            return BusinessRuleValidator.Validate(new AnnexCanOnlyBeAttachedToActiveBindingContractRule(TerminatedAt, ExpiringAt, now),
                                                  new AnnexCanOnlyStartDuringBindingContractPeriodRule(ExpiringAt, validFrom))
                                        .Then(_ =>
                                        {
                                            var annex = Annex.Attach(Id, validFrom);
                                            AttachedAnnexes.Add(annex);

                                            return annex.Id;
                                        });
        }

        public ErrorOr<Success> Terminate(DateTimeOffset terminatedAt)
        {
            return BusinessRuleValidator.Validate(new TerminationIsPossibleOnlyAfterThreeMonthsHavePassedRule(BindingFrom, terminatedAt))
                                        .Then(_ =>
                                        {
                                            TerminatedAt = terminatedAt;

                                            var domainEvent = BindingContractTerminatedDomainEvent.Raise(terminatedAt);

                                            return new Success();
                                        });
        }
    }
    
    // record struct mora, jer zeli value type not reference type + da poredim by value not by reference
    public record struct ContractId(Guid Value)
    {
        public static ContractId Create()
        {
            return new ContractId(Guid.NewGuid());
        }
    }

    public readonly record struct BindingContractId(Guid Value)
    {
        public static BindingContractId Create()
        {
            return new BindingContractId(Guid.NewGuid());
        }
    }
   
}
