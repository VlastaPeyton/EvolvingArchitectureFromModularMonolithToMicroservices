using Common.Infrastructure.Events;

namespace Contracts.Application.IntegrationEvents
{
    public record ContractSignedEvent(Guid Id,
                                        Guid ContractId,
                                        Guid ContractCustomerId,
                                        DateTimeOffset SignedAt,
                                        DateTimeOffset ExpireAt,
                                        DateTimeOffset OccurredDateTime)
        : IIntegrationEvent
    {
        public static ContractSignedEvent Create(Guid contractId,
                                                 Guid contractCustomerId,
                                                 DateTimeOffset signedAt,
                                                 DateTimeOffset expireAt,
                                                 DateTimeOffset occuredAt)
        {
            return new ContractSignedEvent(Guid.NewGuid(), contractId, contractCustomerId, signedAt, expireAt, occuredAt);
        }
    }
}
