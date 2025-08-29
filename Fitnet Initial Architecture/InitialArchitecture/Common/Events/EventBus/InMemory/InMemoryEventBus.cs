using MediatR;

namespace InitialArchitecture.Common.Events.EventBus.InMemory
{   
    // Posto koristim InMemory Event Bus, moram pomocu MediatR da Publish-Subscribe radim
    internal sealed class InMemoryEventBus(IMediator mediator) : IEventBus
    {   // Primary constructor koristim umesto obicnog ctor

        // Mora metoda zbog interface
        public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken) where TEvent : IIntegrationEvent
        {
            await mediator.Publish(@event, cancellationToken);
        }
    }
}
