using Common.Domain.BusinessRules;
using ErrorOr;

namespace Contracts.Domain.SignContract.BusinessRules
{
    internal sealed class ContractCanOnlyBeSignedWithin30DaysFromPreparationRule : IBusinessRule
    {
        private readonly DateTimeOffset _preparedAt;
        private readonly DateTimeOffset _signedAt;

        public ContractCanOnlyBeSignedWithin30DaysFromPreparationRule(DateTimeOffset preparedAt, DateTimeOffset signedAt)
        {
            _preparedAt = preparedAt;
            _signedAt = signedAt;
        }

        public bool IsMet()
        {
            var timeDifference = _signedAt.Date - _preparedAt.Date;

            return timeDifference <= TimeSpan.FromDays(30);
        }

        public Error Error => BusinessRuleError.Create(nameof(ContractCanOnlyBeSignedWithin30DaysFromPreparationRule), "Contract can only be signed within 30 days from preparation");
    }
}
