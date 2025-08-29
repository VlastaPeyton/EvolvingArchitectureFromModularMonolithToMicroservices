using Passes.DataAccess;

namespace Passes.API.GetAllPasses
{
    internal record GetAllPassesResponse(IReadOnlyCollection<PassDto> Passes)
    {
        internal static GetAllPassesResponse Create(IReadOnlyCollection<PassDto> passes) => new(passes);
    }

    
}
