
namespace Contracts.Infrastructure.EventBus
{
    internal sealed class EventBusOptions
    {
        public string? Host { get; init; }
        public string? UserName { get; init; }
        public string? Password { get; init; }
    }
}
