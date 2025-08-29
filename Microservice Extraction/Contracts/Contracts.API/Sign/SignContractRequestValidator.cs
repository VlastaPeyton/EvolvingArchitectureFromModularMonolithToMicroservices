
using FluentValidation;

namespace Contracts.API.Sign
{   
    // Request se validira pre nego sto udje u Endpoint
    internal sealed class SignContractRequestValidator : AbstractValidator<SignContractRequest>
    {   // Zbog AbstractValidator<SignContractRequest>, automatski u RequestValidationApiFilter (Common.sln) zna da treba pozvati SignContractRequestValidator 
        public SignContractRequestValidator() 
        {
            RuleFor(signContractRequest => signContractRequest.SignedAt).NotEmpty();
        }
    }
}
