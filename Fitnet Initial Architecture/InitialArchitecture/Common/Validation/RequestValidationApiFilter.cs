
using System.Net;
using FluentValidation;

namespace InitialArchitecture.Common.Validation
{   
    // Klasa mora da implementira IEndpointFilter zbog EndpointBuilderExtensions.cs gde je dodeljujem u AddEndpointFilter
    internal sealed class RequestValidationApiFilter<TRequestToValidate> : IEndpointFilter where TRequestToValidate : class
    {   
        // Mora ova metoda zbog interface 
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {   // context sadrzi info about trenutni poziv of Minimal API Endpoint (argumente, koji su tipa object?, koje Minimal API Endpoint prima, HTTP Request polja...)
            // next sluzi da pozove sledeci Endpoint Filter ako ga ima in pipeline

            var requestToValidate = context.Arguments.FirstOrDefault(argument => argument?.GetType() == typeof(TRequestToValidate)) as TRequestToValidate;
            // Pogleda argumente prosledjene to Minimal API Endpoint i pronadje TRequestToValidate. Mora "as TRequestToValidate", jer svi arguenti su object? type u context

            var validator = context.HttpContext.RequestServices.GetService<IValidator<TRequestToValidate>>();  // FluentValidation from NuGet
            if (validator is null)
                return await next.Invoke(context); // Pozove sledeci Endpoint Filter i kad odradi sve filtere, onda nastavlja u Minimal API Endpoint

            var validationResult = await validator.ValidateAsync(requestToValidate); // Pokrece PrepareContractRequestValidator ili SignContractRequestValidator (jer sam ih added to DI in RequestValidationExtensions) u zavisnosti da li je TRequestToValidate PrepareContractRequest ili SignContractRequest
            if (validationResult.IsValid)
                return await next.Invoke(context); 

            // If not valid 
            var errors = validationResult.ToDictionary();
            return Results.ValidationProblem(errors, statusCode: (int)HttpStatusCode.BadRequest);
        }
    }
}
