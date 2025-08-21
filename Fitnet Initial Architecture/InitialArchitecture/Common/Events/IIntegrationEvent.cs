using MediatR;

namespace InitialArchitecture.Common.Events
{
    // In-memory Event Bus zahteva MediatR 
    // Zbog INotificationHandler, IIntegrationEventHandler automatski zna kad se Publish IIntegrationEvent jer on ima INotification
    internal interface IIntegrationEvent : INotification 
    {
        Guid Id { get; }
        DateTimeOffset OccuredDateTime { get; }
    }
}
