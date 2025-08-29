using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Contracts.API.Prepare
{
    // Request se validira pre nego sto udje u Endpoint
    // Zbog AbstractValidator<PrepareContractRequest>, automatski u RequestValidationApiFilter (Common.sln) zna da treba pozvati PrepareContractRequestValidator 
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
