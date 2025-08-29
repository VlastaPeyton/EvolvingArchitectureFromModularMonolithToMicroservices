namespace Common.Infrastructure.Events.EventBus
{   
    // Objasnjeno u internalarchitecture 
    public interface IEventBus
    {
        Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken) where TEvent : IIntegrationEvent;
    }
}
