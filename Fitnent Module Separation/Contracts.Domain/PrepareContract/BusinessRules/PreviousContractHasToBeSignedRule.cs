using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.BusinessRules;

namespace Contracts.Domain.PrepareContract.BusinessRules
{
    internal sealed class PreviousContractHasToBeSignedRule : IBusinessRule
    {
        private readonly bool? _signed;
        public PreviousContractHasToBeSignedRule(bool? signed) => _signed = signed;
        public bool IsMet() => _signed is true or null;
        public string Error => "Previous contract must be signed by the customer";
    }
}
