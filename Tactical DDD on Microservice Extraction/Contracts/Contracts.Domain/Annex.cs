

using Common.Domain;
using Contracts.Domain.AttachAnnexToBindingContract;
using Contracts.Domain.CustomId;
using static Contracts.Domain.BindingContract;

namespace Contracts.Domain
{   
    // Ovo ce biti posebna tabela u bazi.
    public sealed class Annex : Entity
    {   // AnnexId se radi umesto Guid kako bih izbegao primitive obsession. Znam iz EShopMicroservices
        public AnnexId Id { get; init; }
        public BindingContractId BindingContractId { get; init; }
        public DateTimeOffset ValidFrom { get; init; }

        // EF Core needs this to create non-primitive types
        private Annex() { }

        private Annex(BindingContractId bindingContractId, DateTimeOffset validFrom)
        {
            Id = AnnexId.Create();
            BindingContractId = bindingContractId;
            ValidFrom = validFrom;

            var annexAttachedToBindingContractDomainEvent = AnnexAttachedToBindingContractDomainEvent.Raise(Id, BindingContractId, ValidFrom);
            RecordDomainEvent(annexAttachedToBindingContractDomainEvent);
        }

        public static Annex Attach(BindingContractId bindingContractId, DateTimeOffset validFrom)
        {
            return new Annex(bindingContractId, validFrom);
        }
    }

    // record struct mora, jer zeli value type not reference type + da poredim by value not by reference
    public readonly record struct AnnexId(Guid Value)
    {
        public static AnnexId Create()
        {
            return new AnnexId(Guid.NewGuid());
        }
    }
}
