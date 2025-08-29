using InitialArchitecture.Contracts.PrepareContract;
using InitialArchitecture.Contracts.SignContract;

namespace InitialArchitecture.Contracts
{   
    // Extension za IEndpointRouteBuilder jer se on koristi za Minimal API Endpoint definition
    internal static class ContractsEndpointsExtensions
    {
        public static void MapContracts(this IEndpointRouteBuilder app) // => u Program.cs mora app.MapContracts
        {
            app.MapPrepareContract(); // MapPrepareContract extension iz PrepareContractEndpointExtension.cs
            app.MapSignContract();    // MapSignContract extension iz SignContractEndpointExtension.cs 
        }
    }
}
