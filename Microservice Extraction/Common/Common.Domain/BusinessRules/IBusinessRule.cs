
namespace Common.Domain.BusinessRules
{
    public interface IBusinessRule
    {
        bool IsMet();
        string Error { get; }
    }
}
