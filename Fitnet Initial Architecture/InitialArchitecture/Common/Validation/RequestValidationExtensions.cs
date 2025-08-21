using FluentValidation;

namespace InitialArchitecture.Common.Validation
{   
    // Registruje u Program.cs DI PrepareContractRequestValidator i SignContractRequestValidator da to ne bih pisao u Program.cs 
    internal static class RequestValidationExtensions
    {   // IServiceCollection, jer se to koristi za DI u Program.cs
        internal static IServiceCollection AddRequestValidations(this IServiceCollection services)
        {    // Built-in metoda za IServiceCollection
            return services.AddValidatorsFromAssemblyContaining<Program>(includeInternalTypes: true); // => u Program.cs mogu builder.Services.AddRequestValidations()...
            /* 1. Scan assembly tj InternalArchitecture project ovaj
               2. Find all classes that implement AbstractValidator<T> (FluentValidation) tj pronadje PrepareContractRequestValidator i SignContractRequestValidator
               3. Registers them to DI 
               4. includeInternalTypes: true - jer sam stavio da su ova 2 validatora internal 
               5. Zbog ovoga, u RequestValidationApiFilter validator.ValidateAsync ce da pokrene zeljeni validator iz tacke 2
            */
        }
    }
}
