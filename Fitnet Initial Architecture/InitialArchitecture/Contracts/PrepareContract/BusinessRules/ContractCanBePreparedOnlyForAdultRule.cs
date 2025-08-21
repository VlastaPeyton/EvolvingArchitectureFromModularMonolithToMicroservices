using InitialArchitecture.Common.BusinessRuleEngine;

namespace InitialArchitecture.Contracts.PrepareContract.BusinessRules
{
    internal sealed class ContractCanBePreparedOnlyForAdultRule : IBusinessRule
    {
        private readonly int _age;
        public ContractCanBePreparedOnlyForAdultRule(int age) => _age = age;
        public bool IsMet() => _age >= 18;
        public string Error => "Contract cannot be prepared for a person under the age of 18";
    }
}
