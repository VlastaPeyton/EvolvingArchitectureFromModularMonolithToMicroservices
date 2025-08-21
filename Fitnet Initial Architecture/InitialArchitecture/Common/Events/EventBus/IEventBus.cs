namespace InitialArchitecture.Common.Events.EventBus
{
    internal interface IEventBus
    {   // Mora @event, jer event je reserverd keyword 
        // Obzirom da je TEvent argument, mora <TEvent> postojati, jer ovo je dobra praksa za EventBus posto generic omogucava da metoda radi sa tipom a @event da prosledim objekat tog tipa
        Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken) where TEvent : IIntegrationEvent;
    }
}
