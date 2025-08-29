using InitialArchitecture.Common.BusinessRuleEngine;

namespace InitialArchitecture.Contracts.PrepareContract.BusinessRules
{
    internal sealed class PreviousContractHasToBeSignedRule : IBusinessRule
    {
        private readonly bool? _signed;

        public PreviousContractHasToBeSignedRule(bool? signed) => _signed = signed;

        public bool IsMet() => _signed is true or null;

        public string Error => "Previous contract must be signed by the customer";
    }
}
