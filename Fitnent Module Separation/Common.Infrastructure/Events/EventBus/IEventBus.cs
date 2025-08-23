namespace Common.Infrastructure.Events.EventBus
{
    public interface IEventBus
    {
        Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken) where TEvent : IIntegrationEvent;
    }
}
