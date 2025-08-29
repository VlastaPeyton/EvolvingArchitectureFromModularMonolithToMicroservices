using InitialArchitecture.Common.Events;

namespace InitialArchitecture.Passes.MarkPassAsExpired.Events
{   
    // Objasnjeno u Contracts
    internal record PassExpiredEvent(Guid Id,
                                     Guid PassId,
                                     Guid CustomerId, 
                                     DateTimeOffset OccuredDateTime)
        : IIntegrationEvent
    {
        public static PassExpiredEvent Create(Guid passId, Guid customerId, DateTimeOffset occuredAt)
        {
            return new PassExpiredEvent(Guid.NewGuid(), passId, customerId, occuredAt);
        }
    }
}
