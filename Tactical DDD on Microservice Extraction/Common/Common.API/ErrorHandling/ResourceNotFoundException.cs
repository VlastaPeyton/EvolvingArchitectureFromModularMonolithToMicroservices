

namespace Common.API.ErrorHandling
{   
    // Ovo mi vise ne treba ali neka ga zbog ExceptionMiddleware gde koristim ovo 
    public sealed class ResourceNotFoundException(Guid id) : InvalidOperationException($"Resource with {id} not found");
}
