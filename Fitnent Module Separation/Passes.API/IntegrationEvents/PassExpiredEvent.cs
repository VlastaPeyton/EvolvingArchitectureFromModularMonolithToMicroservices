﻿using Common.Infrastructure.Events;

namespace Passes.API.IntegrationEvents
{
    public record PassExpiredEvent(Guid Id, Guid PassId, Guid CustomerId, DateTimeOffset OccurredDateTime): IIntegrationEvent
    {
        public static PassExpiredEvent Create(Guid passId, Guid customerId, DateTimeOffset occurredAt)
        {
            return new PassExpiredEvent(Guid.NewGuid(), passId, customerId, occurredAt);
        }
    }
}
