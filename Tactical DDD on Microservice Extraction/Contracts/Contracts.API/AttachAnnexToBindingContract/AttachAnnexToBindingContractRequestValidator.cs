

using FluentValidation;

namespace Contracts.API.AttachAnnexToBindingContract
{   // Request se validira pre nego sto udje u Endpoint
    // Zbog AbstractValidator<AttachAnnexToBindingContractRequest>, automatski u RequestValidationApiFilter (Common.sln) zna da treba pozvati AttachAnnexToBindingContractRequestValidator 
    internal sealed class AttachAnnexToBindingContractRequestValidator : AbstractValidator<AttachAnnexToBindingContractRequest>
    {
        public AttachAnnexToBindingContractRequestValidator() => RuleFor(request => request.ValidFrom).NotEmpty();
    }
}
