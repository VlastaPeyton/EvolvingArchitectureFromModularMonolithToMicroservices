namespace InitialArchitecture.Common.Validation
{   
    // Extension for app.MapMethod tj Minimal API Endpoint, jer app.MapMethod je RouteHandlerBuilder. Adding Validation filter to Minimal API Endpoint 
    internal static class EndpointBuilderExtensions
    {   // Mora generic, jer se radi o tipu requesta, a ne o njegovoj vrednosti, jer tako moze naci validatora za zeljeni request. Za PrepareContractRequest naci ce PrepareContractRequestValidator, a za SignContractRequest naci ce SignContractRequestValidator
        public static RouteHandlerBuilder ValidateRequest<TRequest>(this RouteHandlerBuilder builder) where TRequest : class
        {   // AddEndpointFilter je built-in. Endpoint Filter validira, authorize, logging etc of request before it reaches Minimal API Endpoint and do same for response going from Endpoint to client
            return builder.AddEndpointFilter<RequestValidationApiFilter<TRequest>>();
        }
    }
}
