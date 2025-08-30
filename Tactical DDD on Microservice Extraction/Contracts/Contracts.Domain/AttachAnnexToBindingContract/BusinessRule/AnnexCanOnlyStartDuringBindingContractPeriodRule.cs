using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.BusinessRules;
using ErrorOr;

namespace Contracts.Domain.AttachAnnexToBindingContract.BusinessRule
{
    internal sealed class AnnexCanOnlyStartDuringBindingContractPeriodRule : IBusinessRule
    {
        private readonly DateTimeOffset _annexValidFrom;
        private readonly DateTimeOffset _bindingContractExpiringAt;

        public AnnexCanOnlyStartDuringBindingContractPeriodRule(DateTimeOffset annexValidFrom, DateTimeOffset bindingContractExpiringAt)
        {
            _bindingContractExpiringAt = bindingContractExpiringAt;
            _annexValidFrom = annexValidFrom;
        }

        public Error Error => BusinessRuleError.Create(nameof(AnnexCanOnlyStartDuringBindingContractPeriodRule), "Annex can only start during binding contract period");

        public bool IsMet() => _annexValidFrom <= _bindingContractExpiringAt;
        
    }
}
