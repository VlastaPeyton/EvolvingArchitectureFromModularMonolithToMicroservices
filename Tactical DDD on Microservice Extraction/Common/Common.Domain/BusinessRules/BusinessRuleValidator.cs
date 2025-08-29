
using ErrorOr;

namespace Common.Domain.BusinessRules
{   
    // Menjam BusinessRuleValidator da ne baca exception ako dodje do greske, vec da vrati vrednost koju mogu dalje obraditi
    public static class BusinessRuleValidator
    {
        public static ErrorOr<Success> Validate(params IBusinessRule[] rules)
        {
            var errors = rules.Where(rule => !rule.IsMet()).Select(rule => rule.Error).ToList();

            return errors.Count != 0 ? (ErrorOr<Success>)errors : new Success(); // Success ne sadrzi podatke
        }
    }
}
