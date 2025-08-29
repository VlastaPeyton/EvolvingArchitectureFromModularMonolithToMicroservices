
namespace InitialArchitecture.Passes.GetAllPasses
{   
    // Kao i Request, i Response je record obicno
    internal record GetAllPassesResponse(IReadOnlyCollection<PassDTO> Passes)
    {
        public static GetAllPassesResponse Create(IReadOnlyCollection<PassDTO> passDTOs)
        {
            return new GetAllPassesResponse(passDTOs);
        }
    }
   
}
