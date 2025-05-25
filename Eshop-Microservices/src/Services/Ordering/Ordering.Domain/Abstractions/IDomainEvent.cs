namespace Ordering.Domain.Abstractions;

/*
  Represents a Domain Event—a way for entities/aggregates to broadcast that something has happened in the domain.

    - Implements INotification from MediatR, allowing domain events to be published via the MediatR pipeline.

    - Contains metadata about the event: EventId, OccurredOn, and EventType.
 */
public interface IDomainEvent : INotification
{
    Guid EventId => Guid.NewGuid();
    public DateTime OccurredOn => DateTime.Now;
    public string EventType => GetType().AssemblyQualifiedName;
}
