using FluentValidation;

namespace InitialArchitecture.Contracts.PrepareContract
{   
    // Ovo ubacim u DI, pomocu RequestValidationExtensions.cs, kako bi RequestValidationApiFilter mogo da validira PrepareContractRequest 
    internal sealed class PrepareContractRequestValidator : AbstractValidator<PrepareContractRequest>
    {   
        public PrepareContractRequestValidator() 
        {
            RuleFor(request => request.CustomerId).NotEmpty();
            RuleFor(request => request.CustomerAge).GreaterThan(18);
            RuleFor(request => request.CustomerHeight).GreaterThan(0);
            RuleFor(request => request.PreparedAt).NotEmpty();
        }
    }
}
