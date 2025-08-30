
using Common.Domain.BusinessRules;
using ErrorOr;

namespace Contracts.Domain.PrepareContract.BusinessRules
{
    internal sealed class ContractCanBePreparedOnlyForAdultRule : IBusinessRule
    {
        private readonly int _age;

        public ContractCanBePreparedOnlyForAdultRule(int age) => _age = age;

        public bool IsMet() => _age >= 18;

        public Error Error => BusinessRuleError.Create(nameof(ContractCanBePreparedOnlyForAdultRule), "Contract cannot be prepared for a person who is not adult");
    }
}
