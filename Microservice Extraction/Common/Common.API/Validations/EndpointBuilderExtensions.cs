
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Common.API.Validations
{
    public static class EndpointBuilderExtensions
    {
        // Mora generic jer koristim RequestValidaitonApiFilter koji ima generik, jer bez generic, za svaki Request type bih morao posebni ValidateRequest i RequestValidationApiFilter praviti
        public static RouteHandlerBuilder ValidateRequest<TRequest>(this RouteHandlerBuilder builder) where TRequest : class
        {
            return builder.AddEndpointFilter<RequestValidationApiFilter<TRequest>>();
        }
    }
}
