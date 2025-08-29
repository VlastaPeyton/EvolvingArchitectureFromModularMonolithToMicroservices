using InitialArchitecture.Common.Events;

namespace InitialArchitecture.Contracts.SignContract.Events
{   
    // Record, jer za class ne mogu priamry constructor ako implementiram interface + Event je generalno record type
    internal record ContractSignedEvent(
        Guid Id, // Iz IIntegrationEvent, pa moram navesti i ovde
        Guid ContractId,
        Guid ContractCustomerId,
        DateTimeOffset SignedAt,
        DateTimeOffset ExpireAt,
        DateTimeOffset OccuredDateTime // Iz IIntegrationEvent, pa moram navesti i ovde
        ) : IIntegrationEvent
    {
        public static ContractSignedEvent Create(Guid contractId, Guid contractCustomerId, DateTimeOffset signedAt, DateTimeOffset expireAt, DateTimeOffset occurredAt)
        {
            return new ContractSignedEvent(Guid.NewGuid(), contractId, contractCustomerId, signedAt, expireAt, occurredAt);
        }
    };

    // Bice handlovan u Offers.RegisterPass.Events.ContractSignedEventHandler
}
