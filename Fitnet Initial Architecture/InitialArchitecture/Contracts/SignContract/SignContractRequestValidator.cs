using FluentValidation;

namespace InitialArchitecture.Contracts.SignContract
{
    // Ovo ubacim u DI pomocu RequestValidationExtensions.cs, kako bi RequestValidationApiFilter mogo da validira SignContractRequest 
    internal sealed class SignContractRequestValidator : AbstractValidator<SignContractRequest>
    {
        public SignContractRequestValidator()
        {
            RuleFor(signContractRequest => signContractRequest.SignedAt).NotEmpty();
        }
    }
}
