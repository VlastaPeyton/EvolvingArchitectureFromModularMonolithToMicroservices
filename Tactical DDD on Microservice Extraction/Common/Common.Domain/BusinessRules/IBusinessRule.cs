
using ErrorOr;

namespace Common.Domain.BusinessRules
{   
    // Modifikujem IBusinessRule da Error ne bude string, vec Error zbog BusinessRuleValidator
    public interface IBusinessRule
    {
        bool IsMet();
        Error Error { get; } 
    }
}
