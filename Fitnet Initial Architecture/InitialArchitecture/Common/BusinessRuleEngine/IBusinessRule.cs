namespace InitialArchitecture.Common.BusinessRuleEngine
{
    internal interface IBusinessRule
    {   // Iako je internal sve, ne koristim internal za polja i metode, vec public, jer generalno polja/metode su private or public
        public bool IsMet();
        public string Error { get; } 
    }
}
