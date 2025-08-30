using System;
using System.Collections.Generic;

using Common.Domain.BusinessRules;
using ErrorOr;

namespace Contracts.Domain.TerminateBindingContract.BusinessRules
{
    internal sealed class TerminationIsPossibleOnlyAfterThreeMonthsHavePassedRule(DateTimeOffset bindingFrom, DateTimeOffset terminatedAt) : IBusinessRule
    {
        private const int ThreeMonths = 3;
        public bool IsMet()
        {
            var threeMonthsFromBinding = bindingFrom.AddMonths(ThreeMonths);

            return terminatedAt >= threeMonthsFromBinding;
        }

        public Error Error
        {
            get
            {
                var threeMonthsFromSignDate = bindingFrom.AddMonths(ThreeMonths);
                var daysRemaining = (threeMonthsFromSignDate - terminatedAt).Days;

                var error = $"Termination is not possible until three months have passed. '{daysRemaining}' days remaining";

                return BusinessRuleError.Create(nameof(TerminationIsPossibleOnlyAfterThreeMonthsHavePassedRule), error);
            }
        }
    }
}
