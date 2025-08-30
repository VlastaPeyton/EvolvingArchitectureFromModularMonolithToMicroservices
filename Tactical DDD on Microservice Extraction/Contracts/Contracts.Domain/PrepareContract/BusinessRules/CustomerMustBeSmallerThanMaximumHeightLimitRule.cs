

using Common.Domain.BusinessRules;
using ErrorOr;

namespace Contracts.Domain.PrepareContract.BusinessRules
{
    internal sealed class CustomerMustBeSmallerThanMaximumHeightLimitRule : IBusinessRule
    {
        private const int MaximumHeight = 210;

        private readonly int _height;

        public CustomerMustBeSmallerThanMaximumHeightLimitRule(int height) => _height = height;

        public bool IsMet() => _height <= MaximumHeight;

        public Error Error => BusinessRuleError.Create(nameof(CustomerMustBeSmallerThanMaximumHeightLimitRule), "Customer's height must fit maximum limit for gym instruments");
    }
}
