
namespace Common.Domain
{   
    // Entity in domain model. Znam iz EShopMicroservices.
    public abstract class Entity
    {
        private IList<IDomainEvent>? _domainEvents;

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly() ?? new List<IDomainEvent>().AsReadOnly();

        protected void RecordDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents ??= []; // if(_domainEvents is null) _domainEvents = new List<IDomainEvent>();
            _domainEvents.Add(domainEvent);
        }
    }
}
