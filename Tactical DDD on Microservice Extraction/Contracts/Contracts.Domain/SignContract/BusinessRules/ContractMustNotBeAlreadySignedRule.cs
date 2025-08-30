using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.BusinessRules;
using ErrorOr;

namespace Contracts.Domain.SignContract.BusinessRules
{
    internal sealed class ContractMustNotBeAlreadySignedRule(bool signed) : IBusinessRule
    {
        public bool IsMet() => !signed;
        public Error Error => BusinessRuleError.Create(nameof(ContractMustNotBeAlreadySignedRule), "Contract must not be already signed");
    }
}
