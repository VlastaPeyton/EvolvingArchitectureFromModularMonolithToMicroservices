namespace Common.API.ErrorHandling
{
    public sealed class ResourceNotFoundException(Guid id) : InvalidOperationException($"Resource with '{id}' not found ")
    {
    }
}
