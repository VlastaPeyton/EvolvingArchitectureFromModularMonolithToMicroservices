using System.Runtime.ConstrainedExecution;

namespace InitialArchitecture.Common.Events.EventBus
{
    internal interface IEventBus
    {   // Mora @event, jer event je reserverd keyword 
        /*<TEvent> - u konkretnoj implementaciji ove metode, znači da će MediatR moći da pronađe tačan event handler koji obrađuje baš taj tip događaja.
        Bez<TEvent>, Mediatr ne bi znao koji tačno handler da pozove, jer on mapira handlere po konkretnom tipu događaja, a ne samo po interfejsu. 
        */
                Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken) where TEvent : IIntegrationEvent;
    }
}
