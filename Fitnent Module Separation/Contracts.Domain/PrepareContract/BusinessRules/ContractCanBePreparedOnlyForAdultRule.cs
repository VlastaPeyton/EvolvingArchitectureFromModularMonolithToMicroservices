using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.BusinessRules;

namespace Contracts.Domain.PrepareContract.BusinessRules
{
    internal sealed class ContractCanBePreparedOnlyForAdultRule : IBusinessRule
    {
        private readonly int _age;
        public ContractCanBePreparedOnlyForAdultRule(int age) => _age = age;
        public bool IsMet() => _age > 18;
        public string Error => "Contract cannot be prepared for a person who is not adult";
    }
}
