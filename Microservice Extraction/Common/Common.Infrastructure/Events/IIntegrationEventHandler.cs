
using MediatR;

namespace Common.Infrastructure.Events
{   
    // Bez TEvent, MediatR ne bi znao koji Handler da pozove, inace bez generic, morao bih handler praviti za svaki tip Integration Eventa posebno
    public interface IIntegrationEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IIntegrationEvent
    {
    }
}
