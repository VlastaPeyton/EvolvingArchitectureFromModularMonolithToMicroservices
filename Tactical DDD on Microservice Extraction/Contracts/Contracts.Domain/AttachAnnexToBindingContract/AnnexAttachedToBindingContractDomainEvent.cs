
using Common.Domain;
using Contracts.Domain.CustomId;

namespace Contracts.Domain.AttachAnnexToBindingContract
{
    public record AnnexAttachedToBindingContractDomainEvent(Guid Id, AnnexId AnnexId, BindingContractId BindingContractId, DateTimeOffset ValidFrom, DateTime OccurredAt) : IDomainEvent
    { // Id i OccurredAt mora zbog IDomainEvent
        public static AnnexAttachedToBindingContractDomainEvent Raise(AnnexId annexId, BindingContractId bindingContractId, DateTimeOffset validFrom)
        {
            return new AnnexAttachedToBindingContractDomainEvent(Guid.NewGuid(), annexId, bindingContractId, validFrom, DateTime.UtcNow);
        }
    }
}
