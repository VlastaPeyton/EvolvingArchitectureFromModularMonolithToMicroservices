using MediatR;

namespace InitialArchitecture.Common.Events
{   
    // In-memory Event Bus zahteva MediatR za Publish-Subscribe
    // Zbog INotificationHandler, IIntegrationEventHandler automatski zna kad se Publish IIntegrationEvent jer on ima INotification
    internal interface IIntegrationEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IIntegrationEvent;
    
}
