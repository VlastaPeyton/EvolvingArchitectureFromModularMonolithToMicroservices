
namespace Passes.API.EventBus
{
    internal sealed class EventBusOptions
    {   // Ovo mora da se poklopi sa appsettings.json 
        public string? Host { get; init; }
        public string? Username { get; init; }
        public string? Password { get; init; }
    }
}
