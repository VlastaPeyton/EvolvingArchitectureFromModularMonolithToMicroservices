using InitialArchitecture.Passes.Data;

namespace InitialArchitecture.Passes.GetAllPasses
{
    internal record PassDTO(Guid Id, Guid CustomerID)
    {
        public static PassDTO From(Pass contract)
        {
            return new PassDTO(contract.Id, contract.CustomerId);
        }
    }
}
