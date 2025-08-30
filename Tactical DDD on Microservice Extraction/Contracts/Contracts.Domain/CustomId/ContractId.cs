

namespace Contracts.Domain.CustomId
{
    // record struct mora, jer zeli value type not reference type + da poredim by value not by reference
    public record struct ContractId(Guid Value)
    {
        public static ContractId Create()
        {
            return new ContractId(Guid.NewGuid());
        }
    }
}
