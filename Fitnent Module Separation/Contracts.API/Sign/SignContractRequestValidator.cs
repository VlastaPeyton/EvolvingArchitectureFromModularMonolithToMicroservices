using FluentValidation;

namespace Contracts.API.Sign
{
    internal class SignContractRequestValidator : AbstractValidator<SignContractRequest>
    {
        public SignContractRequestValidator() => RuleFor(signContractRequest => signContractRequest.SignedAt).NotEmpty();

    }
}
