using MediatR;

namespace InitialArchitecture.Common.Events
{
    // In-memory Event Bus zahteva MediatR 
    // Zbog INotificationHandler, IIntegrationEventHandler automatski zna kad se Publish IIntegrationEvent jer IIntegrationEvent ima INotification i onda se Handle metoda automatski pokrece 
    internal interface IIntegrationEvent : INotification 
    {
        Guid Id { get; }
        DateTimeOffset OccuredDateTime { get; }
    }
}
