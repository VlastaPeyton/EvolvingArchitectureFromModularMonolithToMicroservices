
namespace Contracts.IntegrationEvents
{   
    // Ovo je IntegrationEvent, ali ne nasledjuje IIntegrationEvent, jer ovo ide u RabbitMQ preko MassTransit, a IIntegrationEvent je za MediatR, a sad MediatR koristicu za DomainEvent
    public record ContractSignedEvent(Guid Id, Guid ContractId, Guid ContractCustomerId, DateTimeOffset SignedAt, DateTimeOffset ExpireAt, DateTimeOffset OccurredDateTime)
    {
        public static ContractSignedEvent Create(Guid contractId, Guid contractCustomerId, DateTimeOffset signedAt, DateTimeOffset expireAt, DateTimeOffset occurredAt)
        {
            return new ContractSignedEvent(Guid.NewGuid(), contractId, contractCustomerId, signedAt, expireAt, occurredAt);
        }
    }
}
