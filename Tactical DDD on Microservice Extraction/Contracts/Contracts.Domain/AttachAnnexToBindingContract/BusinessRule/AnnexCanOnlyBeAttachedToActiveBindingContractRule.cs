
using Common.Domain.BusinessRules;
using ErrorOr;

namespace Contracts.Domain.AttachAnnexToBindingContract.BusinessRule
{
    internal sealed class AnnexCanOnlyBeAttachedToActiveBindingContractRule : IBusinessRule
    {
        private readonly DateTimeOffset? _bindingContractTerminatedAt;
        private readonly DateTimeOffset _bindingContractExpiringAt;
        private readonly DateTimeOffset _now;

        public AnnexCanOnlyBeAttachedToActiveBindingContractRule(DateTimeOffset? bindingContractTerminatedAt, DateTimeOffset bindingContractExpiringAt, DateTimeOffset now)
        {
            _bindingContractTerminatedAt = bindingContractTerminatedAt;
            _bindingContractExpiringAt = bindingContractExpiringAt;
            _now = now;
        }

        public Error Error => BusinessRuleError.Create(nameof(AnnexCanOnlyBeAttachedToActiveBindingContractRule), "Annex can only be attached to active binding contract");

        public bool IsMet() => !_bindingContractTerminatedAt.HasValue && _bindingContractExpiringAt > _now;
    }
}
