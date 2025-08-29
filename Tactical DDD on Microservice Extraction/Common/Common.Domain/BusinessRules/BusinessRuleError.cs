

using ErrorOr;
namespace Common.Domain.BusinessRules
{   
    // Umesto BusinessRuleValidationException, pravim ovu klasu 
    public static class BusinessRuleError
    {
        public const int Type = 100;
        public static Error Create(string code, string desc)
        {
            return Error.Custom(Type, code, desc);
        }
    }
}
