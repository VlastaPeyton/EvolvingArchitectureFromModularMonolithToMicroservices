using InitialArchitecture.Common.Events;

namespace InitialArchitecture.Passes.RegisterPass.Events
{   
    // Objasnjeno u Contracts
    internal record PassRegisteredEvent(Guid Id, 
                                        Guid PassId,
                                        DateTimeOffset OccuredDateTime)
        : IIntegrationEvent
    {

        public static PassRegisteredEvent Create(Guid passId)
        {
            return new PassRegisteredEvent(Guid.NewGuid(), passId, DateTimeOffset.UtcNow);
        }
    }
}
