using MediatR;

namespace Common.Infrastructure.Events.EventBus.InMemory
{
    internal sealed class InMemoryEventBus(IPublisher mediator) : IEventBus
    {
        /*<TEvent> - znači da će MediatR moći da pronađe tačan event handler koji obrađuje baš taj tip događaja.
        Bez<TEvent>, Mediatr ne bi znao koji tačno handler da pozove, jer on mapira handlere po konkretnom tipu događaja, a ne samo po interfejsu. 
        */
        public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken) where TEvent : IIntegrationEvent
        {
            await mediator.Publish(@event, cancellationToken);
        }
    }
}
