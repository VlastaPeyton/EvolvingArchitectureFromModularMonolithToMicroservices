using System.Net;
using FluentValidation;

namespace Common.API.Validations
{   // Generic, jer ova klasa primace onda sve vrste Request za bilo koji Endpoint. Bez generic, za svaki Request type bih morao poseban filter praviti
    internal sealed class RequestValidationApiFilter<TRequestToValidate> : IEndpointFilter where TRequestToValidate : class
    {   
        // Mora metoda zbog interface
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {   // context sadrzi info about trenutni poziv of Minimal API Endpoint (argumente, koji su tipa object?, koje Minimal API Endpoint prima ( HTTP Request polja itd...)
            // next sluzi da pozove sledeci Endpoint Filter ako ga ima in pipeline

            var requestToValidate = context.Arguments.FirstOrDefault(argument => argument?.GetType() == typeof(TRequestToValidate)) as TRequestToValidate;
            // Pogleda argumente proslednje to Minimal API Endpoint i pronadje TRequestToValidate. Mora "as TRequestToValidate", jer svi arguenti su object? type u context

            var validator = context.HttpContext.RequestServices.GetService<IValidator<TRequestToValidate>>(); // IValidator je FluentValidation
            // U odnosu na tip TRequestToValidate nadje validator koji treba
            if (validator is null)
                return await next.Invoke(context); // Pozove sledeci Endpoint Filter ako ga ima, i kad odradi sve filtere, onda nastavlja u Minimal API Endpoint

            var validationResult = await validator.ValidateAsync(requestToValidate!); // Pokrece PrepareContractRequestValidator ili SignContractRequestValidator (u Contracts.sln se nalaze) (jer su nasledili AbstractValidator) u zavisnosti da li je TRequestToValidate PrepareContractRequest ili SignContractRequest

            if (validationResult.IsValid)
                return await next.Invoke(context);

            var errors = validationResult.ToDictionary();

            return Results.ValidationProblem(errors, statusCode: (int)HttpStatusCode.BadRequest);

        }
    }
}
