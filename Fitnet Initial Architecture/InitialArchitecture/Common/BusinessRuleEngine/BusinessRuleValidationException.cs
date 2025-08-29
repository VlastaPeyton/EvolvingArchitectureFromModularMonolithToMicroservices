namespace InitialArchitecture.Common.BusinessRuleEngine
{
    public class BusinessRuleValidationException : InvalidOperationException
    {
        internal BusinessRuleValidationException(string message) : base(message) { }
    }
}
