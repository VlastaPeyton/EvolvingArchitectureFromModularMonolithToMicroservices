
using Passes.DataAccess;

namespace Passes.API.GetAllPasses
{
    internal record PassDTO(Guid Id, Guid CustomerId)
    {
        internal static PassDTO From(Pass contract) => new(contract.Id, contract.CustomerId);
    }
}
