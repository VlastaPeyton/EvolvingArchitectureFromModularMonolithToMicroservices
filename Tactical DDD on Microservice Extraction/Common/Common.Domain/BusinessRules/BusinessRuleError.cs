

using ErrorOr;
namespace Common.Domain.BusinessRules
{   
    // Umesto BusinessRuleValidationException, pravim ovu klasu 
    public static class BusinessRuleError
    {
        public const int Type = 100; // Dodeljujem tip greske koji nije konvencionalan tipa 200,400,404.... kako bih znao da je to BusinessRuleError
        public static Error Create(string code, string desc)
        {
            return Error.Custom(Type, code, desc);
        }
    }
}
