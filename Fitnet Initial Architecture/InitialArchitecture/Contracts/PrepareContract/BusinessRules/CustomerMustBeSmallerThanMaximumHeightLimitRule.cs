using InitialArchitecture.Common.BusinessRuleEngine;

namespace InitialArchitecture.Contracts.PrepareContract.BusinessRules
{
    internal sealed class CustomerMustBeSmallerThanMaximumHeightLimitRule : IBusinessRule
    {
        private const int MaximumHeight = 210;

        private readonly int _height;
        public CustomerMustBeSmallerThanMaximumHeightLimitRule(int height) => _height = height;
        public bool IsMet() => _height <= MaximumHeight;
        public string Error => "Customer height must fit maximum limit for gym instruments";
    }
}
