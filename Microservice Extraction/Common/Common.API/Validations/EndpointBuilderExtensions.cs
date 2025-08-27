namespace Common.API.Validations
{
    public static class EndpointBuilderExtensions
    {   
        // Mora generic jer koristim RequestValidaitonApiFilter koji ima generik, a tamo pise zasto ga ima
        public static RouteHandlerBuilder ValidateRequest<TRequest>(this RouteHandlerBuilder builder) where TRequest: class
        {
            return builder.AddEndpointFilter<RequestValidationApiFilter<TRequest>>();
        }
    }
}
